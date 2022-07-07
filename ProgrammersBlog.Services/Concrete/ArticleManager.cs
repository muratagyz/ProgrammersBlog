using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Complex_Types;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId, a => a.User, b => b.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Succes, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı. ", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, b => b.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı. ", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted, a => a.User, b => b.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı. ", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted && x.IsActive, a => a.User, b => b.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı. ", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(x => x.CategoryId == categoryId && !x.IsDeleted && x.IsActive, a => a.User, b => b.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Succes
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı. ", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", null);
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.MotifiedByName = createdByName;
            article.UserId = 1;

            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Succes, $"{articleAddDto.Title} başlıklı makale başarıyla eklenmiştir.");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.MotifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Succes, $"{articleUpdateDto.Title} başlıklı makale başarıyla güncellenmiştir.");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId);
                article.IsDeleted = true;
                article.MotifiedByName = modifiedByName;
                article.MotifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Succes, $"{article.Title} başlıklı makale başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı.");
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId);
                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Succes, $"{article.Title} başlıklı makale başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı.");
        }
    }
}
