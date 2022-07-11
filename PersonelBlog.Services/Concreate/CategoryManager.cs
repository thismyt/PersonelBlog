using PersonelBlog.Entities.Concreate;
using PersonelBlog.Entities.Dtos;
using PersonelBlog.Services.Abstract;
using PersonelBlog.Shared.Utilities.Result.Abstract;
using PersonelBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelBlog.Data.Abstract;
using PersonelBlog.Shared.Utilities.Result.Abstract.ComplexTypes;
using PersonelBlog.Shared.Utilities.Results.Concreate;
using AutoMapper;

namespace PersonelBlog.Services.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            await _unitofwork.Categories.AddAsync(category).ContinueWith(t => _unitofwork.SaveAsync()) ;
            //await _unitofwork.SaveAsync();
            return new Result(ResultStatus.Succes, $"{categoryAddDto.Name} adlı kategori oluşturuldu.");
        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitofwork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {                
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedTime = DateTime.Now;
                await _unitofwork.Categories.UpdateAsync(category).ContinueWith(t => _unitofwork.SaveAsync());
                return new Result(ResultStatus.Succes, $"{category.Name} adlı kategori silinmiştir.");
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Böyle kategori bulunamadı.", null);
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitofwork.Categories.GetAsync(c => c.Id == categoryId, c => c.Articles);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Succes, new CategoryDto
                { 
                    Category = category,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitofwork.Categories.GetAllAsync(null, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Succes, new CategoryListDto
                { 
                    Categories = categories,
                    ResultStatus = ResultStatus.Succes
                });

            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı.", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await _unitofwork.Categories.GetAllAsync(c => !c.IsDeleted, c=>c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto> (ResultStatus.Succes, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Succes
                });

            }
            return new DataResult<CategoryListDto> (ResultStatus.Error, "Hiç bir kategori bulunamadı.", null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await _unitofwork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Succes, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Succes
                });

            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı.", null);
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitofwork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                await _unitofwork.Categories.DeleteAsync(category).ContinueWith(t => _unitofwork.SaveAsync());
                return new Result(ResultStatus.Succes, $"{category.Name} adlı kategori veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle kategori bulunamadı.", null);
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;
            await _unitofwork.Categories.UpdateAsync(category).ContinueWith(t => _unitofwork.SaveAsync());
            return new Result(ResultStatus.Succes, $"{categoryUpdateDto.Name} adlı kategori güncellenmiştir.");
        }
    }
}
