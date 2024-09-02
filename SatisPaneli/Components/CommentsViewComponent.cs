using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SatisPaneli.Models;

namespace SatisPaneli.Components
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly Task3RealEcommerceContext _context;

        public CommentsViewComponent(Task3RealEcommerceContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var comments = await _context.Yorumlars.Where(p => (p.Aktiflik == true && p.UrunId == productId)).Select(p => new CommentsModel
            {
                ActivityStatus = p.Aktiflik,
                Date = p.Tarih,
                Comment = p.Yorum,
                CommentId = p.YorumId,
                ProductId = p.UrunId,
                UserId = p.KullaniciId,
                UserName = p.Kullanici.KullaniciAd
            }).ToListAsync();
            var replies = _context.KullaniciYorumCevaps.Where(p => (p.Aktiflik == true && p.Yorum.UrunId == productId)).Select(p => new CommentRepliesModel
            {
                ActivityStatus = p.Aktiflik,
                CommentId = p.YorumId,

                Date = p.Tarih,
                Reply = p.Cevap,
                ReplyId = p.CevapId,
                UserId = p.KullaniciId,
                UserName = p.Kullanici.KullaniciAd
            }).ToList().Concat(await _context.FirmaYorumCevaps.Where(p => (p.Aktiflik == true && p.Yorum.UrunId == productId)).Select(p => new CommentRepliesModel
            {

                ActivityStatus = p.Aktiflik,

                ReplyId = p.CevapId,
                CommentId = p.YorumId,
                CompanyId = p.FirmaId,
                CompanyName = p.Firma.FirmaAd,
                Date = p.Tarih,
                Reply = p.Cevap
            }).ToListAsync()).OrderByDescending(p => p.Date).ToList();

            var modal = comments.Select(comment => new ProductCommentAndRepliesModel
            {
                commentsList = new List<CommentsModel> { comment },
                repliesList = replies.Where(p => p.CommentId == comment.CommentId).ToList()
            }).FirstOrDefault();

            return View(modal);
        }


    }
}
