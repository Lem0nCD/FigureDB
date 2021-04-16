using FigureDB.Common;
using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using FigureDB.Repository;
using FigureDB.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FigureDB.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public const string constr = "Server=.;Database=FigureDB;User Id=sa;Password=sa;";
        public static DbContextOptions<MainContext> CreateDbContextOptions(string databaseName)
        {
            var serviceProvider = new ServiceCollection().
                AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MainContext>();
            builder.UseSqlServer(databaseName)
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
        [TestMethod]
        public async Task CreateTag()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            List<Tag> tags = new List<Tag>()
            {
                new Tag()
                {
                    Color = "#ed6faC",
                    Name = "女"
                },
                new Tag()
                {
                    Color = "#2db7f5",
                    Name = "男"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "无性别"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "全年龄"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "景品"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "人形"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "机甲"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "可动"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "拼装"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "怪兽"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "机械 "
                },

            };
            foreach (var item in tags)
            {
                context.Add<Tag>(item);
            }
            context.SaveChanges();
        }
        [TestMethod]

        public async Task CreateCompany()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Company>(new Company
            {
                Name = "ハセガワ",
                CHNName = "长谷川模型",
                Homepage = "http://www.hasegawa-model.co.jp/",
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateOrigin()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Origin>(new Origin
            {
                Name = "機動戦士ガンダム",
                CHNName = "机动战士高达",
                About = ""
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateCharacter()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Character>(new Character
            {
                Name = "其他",
                CHNName = "其他",
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateSeries()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Series>(new Series
            {
                Name = "ハセガワ 1/72 飛行機シリーズ",
                CHNName = "长谷川 1/72 飞机系列",
                CompanyId = 5,
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateArtist()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            List<Artist> artists = new List<Artist>()
            {
                new Artist()
                {
                    Name = "松浦元樹",
                    CHNName = "松浦元树",
                },
                new Artist()
                {
                    Name = "三月八日",
                    CHNName = "三月八日",
                },
            };
            foreach (var item in artists)
            {
                context.Add<Artist>(item);
            }
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateJob()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            List<Job> jobs = new List<Job>()
            {
                new Job()
                {
                    Name = "原型",
                },
                new Job()
                {
                    Name = "原画",
                },
            };
            foreach (var item in jobs)
            {

            }
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateFigure()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Figure>(new Figure
            {
                CharacterId = 1,
                CHNName = "EVA系列 迷你陈列品手办～Q～feat.三月八日Vol.3 新世纪EVA 葛城美里",
                Dimensions = 0,
                ManufacturerId = 1,
                Materials = "PVC, ABS",
                Name = "エヴァンゲリオンシリーズ ミニディスプレイフィギュア～Q～feat.三月八日Vol.3 新世紀エヴァンゲリオン 葛城ミサト",
                OriginId = 1,
                PublishedId = 1,
                Scale = 90f,
                SeriesId = 2,

            });
            context.SaveChanges();
        }
        //[TestMethod]
        public async Task CreateArtistJob()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            List<ArtistJob> artistJobs = new List<ArtistJob>()
            {
                new ArtistJob()
                {
                    JobId = 1,
                    ArtistId = 1,
                },
                new ArtistJob()
                {
                    JobId = 2,
                    ArtistId = 2,
                },
            };
            foreach (var item in artistJobs)
            {
                context.Add<ArtistJob>(item);
            }
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateFigureTag()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            List<FigureTag> figureTags = new List<FigureTag>()
            {
                new FigureTag()
                {
                    FigureId = new Guid("E743F8F1-96FE-47DD-BDE0-D61B201994BB"),
                    TagId = 1,
                },
                new FigureTag()
                {
                    FigureId = new Guid("E743F8F1-96FE-47DD-BDE0-D61B201994BB"),
                    TagId = 4,
                },
                new FigureTag()
                {
                    FigureId = new Guid("E743F8F1-96FE-47DD-BDE0-D61B201994BB"),
                    TagId = 5,
                },
            };
            foreach (var item in figureTags)
            {
                context.Add<FigureTag>(item);
            }
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateNews()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<News>(new News()
            {
                Content = "EVA系列 迷你陈列品手办～Q～feat.三月八日Vol.3 新世纪EVA 绫波丽",
                Title = "条目创建",
                FigureId = Guid.Parse("d5638ee0-0e9f-4912-a1de-cf26ba3033a0")
            });
            context.SaveChanges();


        }
        [TestMethod]
        public async Task CreateUser()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            var user = new User()
            {
                Email = "123@emali.com",
                Nickname = "123",
            };
            var userIdentitys = new UserIdentity(Model.Entity.IdentityType.Password, EncryptUtil.Encrypt("123"), user.Id);
            context.Add<User>(user);
            context.Add<UserIdentity>(userIdentitys);

            await context.SaveChangesAsync();


        }
        [TestMethod]
        public async Task CreateFigureType()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            var figureType = new FigureType()
            {
                FigureId = Guid.Parse("E743F8F1-96FE-47DD-BDE0-D61B201994BB"),
                Name = "粘土人"
            };
            context.Add<FigureType>(figureType);
            await context.SaveChangesAsync();
        }
        //[TestMethod]
        //public async Task QueryUser()
        //{
        //    var context = new MainContext(CreateDbContextOptions(constr));
        //    var u = new UserService(new GenericRepository<User, Guid>(context), new UnitOfWork(context));
        //    var b = await u.GetUserAsync(Guid.Parse("357CAFEE-6110-4195-B280-DC1101CED232"));
        //    Assert.IsNotNull(b);
        //}
    }
}
