using AutoMapper;
using PersonelBlog.Data.Abstract;
using PersonelBlog.Entities.Concreate;
using PersonelBlog.Entities.Dtos;
using PersonelBlog.Services.Abstract;
using PersonelBlog.Shared.Utilities.Result.Abstract;
using PersonelBlog.Shared.Utilities.Result.Abstract.ComplexTypes;
using PersonelBlog.Shared.Utilities.Results.Abstract;
using PersonelBlog.Shared.Utilities.Results.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Services.Concreate
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        
        public ArticleManager(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        
        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitofwork.Articles.AddAsync(article).ContinueWith(t => _unitofwork.SaveAsync());
            return new Result(ResultStatus.Succes, $"{articleAddDto.Title} başlıklı makale başarı ile eklendi.");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitofwork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitofwork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedTime = DateTime.Now;
                await _unitofwork.Articles.UpdateAsync(article).ContinueWith(t => _unitofwork.SaveAsync());
                return new Result(ResultStatus.Succes, $"{article.Title} başlıklı makale başarı ile silindi.");
            }
            return new Result(ResultStatus.Error, "Makale bulunamadı.");
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitofwork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Succes, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Succes
                }) ;

            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitofwork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count>-1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes
                });

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç bir makale bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitofwork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var articles = await _unitofwork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, ar => ar.User, ar => ar.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Succes
                    });

                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç bir makale bulunamadı.", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitofwork.Articles.GetAllAsync(a => !a.IsDeleted, ar => ar.User, ar => ar.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes
                });

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç bir makale bulunamadı.", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllNonDeletedAndActive()
        {
            var articles = await _unitofwork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, ar => ar.User, ar => ar.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes
                });

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç bir makale bulunamadı.", null);
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitofwork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitofwork.Articles.GetAsync(a => a.Id == articleId);
                await _unitofwork.Articles.DeleteAsync(article).ContinueWith(t => _unitofwork.SaveAsync());
                return new Result(ResultStatus.Succes, $"{article.Title} başlıklı makale veritabanından başarı ile silindi.");
            }
            return new Result(ResultStatus.Error, "Makale bulunamadı.");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitofwork.Articles.UpdateAsync(article).ContinueWith(t => _unitofwork.SaveAsync());
            return new Result(ResultStatus.Succes, $"{articleUpdateDto.Title} başlıklı makale başarı ile güncellendi.");
        }
    }
}
