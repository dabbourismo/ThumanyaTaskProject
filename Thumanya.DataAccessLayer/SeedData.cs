using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thumanya.DataAccessLayer.DatabaseEntities;
using Thumanya.Shared.Dtos.PostDtos;

namespace Thumanya.DataAccessLayer
{
    public static class SeedData
    {
        public static void Initialize(CMSDbContext db)
        {
            //        var authers = new Auther[]
            //        {
            //            new Auther
            //{
            //    Name = "احمد شافعي",
            //    ProfileUrl = "https://example.com/profiles/alice",
            //    ProfileImage = "https://example.com/images/alice.jpg"
            //},
            //new Auther
            //{
            //    Name = "محمد القحطاني",
            //    ProfileUrl = "https://example.com/profiles/bob",
            //    ProfileImage = "https://example.com/images/bob.jpg"
            //},
            //new Auther
            //{
            //    Name = "ايمان اسعد",
            //    ProfileUrl = "https://example.com/profiles/charlie",
            //    ProfileImage = "https://example.com/images/charlie.jpg"
            //}
            //        };


            //db.Authers.AddRange(authers);



            //            var channels = new List<Channel>
            //{
            //    new Channel
            //    {
            //        Id = 1,
            //        Name = "بودكاست فنجان",
            //        Url = "https://example.com/techtalk",
            //        Description = "Latest discussions on technology.",
            //        ChannelTypeId = 1,
            //    },
            //    new Channel
            //    {
            //        Id = 2,
            //        Name = "الجزيرة الوثائقية",
            //        Url = "https://example.com/healthmatters",
            //        Description = "Insights into health and wellness.",
            //        ChannelTypeId = 2,
            //    },
            //    new Channel
            //    {
            //        Id = 3,
            //        Name = "بودكاست",
            //        Url = "https://example.com/financeweekly",
            //        Description = "Your weekly dose of financial advice.",
            //        ChannelTypeId = 1,
            //    }
            //};

            //db.Channels.AddRange(channels);

            var posts = new List<Post>
{
    new Post
    {
        Title = "Understanding AI in 2025",
        Description = "A deep dive into the state of artificial intelligence in 2025.",
        Content = "AI is transforming industries, and this post explores key innovations expected this year.",
        Thumbnail = "https://example.com/images/thumb_ai2025.jpg",
        Cover = "https://example.com/images/cover_ai2025.jpg",
        AudioUrl = "https://example.com/audio/ai2025.mp3",
        VideoUrl = "https://example.com/video/ai2025.mp4",
        IsPaidContent = false,
        PublishDate = new DateTime(2025, 6, 17),
        SponsoredBy = "TechCorp International",
        Duration = 12,
        AuthorId = 2,
        ChannelId = 2
    },
    new Post
    {
        Title = "Online Business Strategies",
        Description = "A step-by-step guide to building a business online.",
        Content = "Explore tools and tactics to grow your digital business.",
        Thumbnail = "https://example.com/images/thumb_business.jpg",
        Cover = "https://example.com/images/cover_business.jpg",
        AudioUrl = "https://example.com/audio/business.mp3",
        VideoUrl = "https://example.com/video/business.mp4",
        IsPaidContent = true,
        PublishDate = new DateTime(2025, 6, 17),
        SponsoredBy = "MarketPro Ltd.",
        Duration = 25,
        AuthorId = 2,
        ChannelId = 1
    },
    new Post
    {
        Title = "Top 10 Travel Destinations",
        Description = "Where to go and why in 2025.",
        Content = "Discover breathtaking places around the world with expert tips.",
        Thumbnail = "https://example.com/images/thumb_travel.jpg",
        Cover = "https://example.com/images/cover_travel.jpg",
        AudioUrl = "https://example.com/audio/travel.mp3",
        VideoUrl = "https://example.com/video/travel.mp4",
        IsPaidContent = false,
        PublishDate = new DateTime(2025, 6, 17),
        SponsoredBy = "Global Adventures",
        Duration = 8,
        AuthorId = 1,
        ChannelId = 2
    },
    new Post
    {
        Title = "The Future of Renewable Energy",
        Description = "New technologies and trends reshaping sustainability.",
        Content = "Green energy sources are gaining momentum globally.",
        Thumbnail = "https://example.com/images/thumb_energy.jpg",
        Cover = "https://example.com/images/cover_energy.jpg",
        AudioUrl = "https://example.com/audio/energy.mp3",
        VideoUrl = "https://example.com/video/energy.mp4",
        IsPaidContent = true,
        PublishDate = new DateTime(2025, 6, 17),
        SponsoredBy = "EcoFuture Solutions",
        Duration = 15,
        AuthorId = 2,
        ChannelId = 2
    },
    new Post
    {
        Title = "Minimalism Made Simple",
        Description = "Declutter your space and your mind.",
        Content = "Minimalism promotes clarity, purpose, and peace.",
        Thumbnail = "https://example.com/images/thumb_minimal.jpg",
        Cover = "https://example.com/images/cover_minimal.jpg",
        AudioUrl = "https://example.com/audio/minimal.mp3",
        VideoUrl = "https://example.com/video/minimal.mp4",
        IsPaidContent = false,
        PublishDate = new DateTime(2025, 6, 17),
        SponsoredBy = "Simple Living Co.",
        Duration = 5,
        AuthorId = 1,
        ChannelId = 1
    },
    new Post
    {
        Title = "Mastering the Art of Cooking",
        Description = "Culinary skills from beginner to advanced.",
        Content = "Discover techniques and secrets used by top chefs.",
        Thumbnail = "https://example.com/images/thumb_cooking.jpg",
        Cover = "https://example.com/images/cover_cooking.jpg",
        AudioUrl = "https://example.com/audio/cooking.mp3",
        VideoUrl = "https://example.com/video/cooking.mp4",
        IsPaidContent = false,
        PublishDate = new DateTime(2025, 6, 17),
        SponsoredBy = "CookWell Academy",
        Duration = 30,
        AuthorId = 2,
        ChannelId = 1
    },
    new Post
    {
        Title = "Learn C# in 30 Days",
        Description = "From beginner to job-ready developer.",
        Content = "Daily lessons and mini-projects to sharpen your C# skills.",
        Thumbnail = "https://example.com/images/thumb_csharp.jpg",
        Cover = "https://example.com/images/cover_csharp.jpg",
        AudioUrl = "https://example.com/audio/csharp.mp3",
        VideoUrl = "https://example.com/video/csharp.mp4",
        IsPaidContent = true,
        PublishDate = new DateTime(2025, 6, 17),
        SponsoredBy = "DevHub Inc.",
        Duration = 20,
        AuthorId = 1,
        ChannelId = 2
    }
};



            //db.Posts.AddRange(posts);

            //db.SaveChanges();
        }
    }
}
