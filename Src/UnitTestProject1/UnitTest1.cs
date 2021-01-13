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
                CHNName = "世嘉",
                Name = "セガ",
                Homepage = "http://sega.jp/",
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateOrigin()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Origin>(new Origin
            {
                Name = "新世紀エヴァンゲリオン",
                CHNName = "新世纪福音战士",
                About = "2000年，一个科学探险队在南极洲针对被称作“第一使徒”亚当的“光之巨人”进行探险。在对其进行接触实验时，“光之巨人”自毁，从而发生了“第二次冲击”，进而导致世界大战。最后，人类人口减半，地轴偏转、气候改变。根据对“第二次冲击”的调查，联合国在日本箱根成立人工进化研究所（即 GEHIRN）从事EVA（指机器人）的发展研究，后GEHIRN利用在人工进化研究所下方发现的巨大空洞建造了总部。另一方面，联合国下属秘密组织SEELE为了使人类进化，开始实行人类补完计划，就是将所有人的灵魂汇集在一起，通过中和每个人的AT力场，使每个人回归LCL之海。2004年，EVA初号机进行启动试验时发生事故，碇真嗣的母亲碇唯消失，碇源渡开始执行“碇源渡版本的人类补完计划”。2010年，GEHIRN被改建成NERV。2015年开始，根据SEELE人类补完计划剧本的安排，一种巨型人形生物“使徒”开始在日本登陆，并向NERV总部进攻，NERV组织EVA消灭使徒。在NERV与使徒作战的同时，碇源渡秘密地执行它自己的计划。随着时间推移，碇源渡的计划逐渐被SEELE发现，NERV与SEELE产生了矛盾并不断恶化。Director's Cut版本的第21～24集由剧场版《Death》篇剪辑而成，收录在20周年纪念版的蓝光中。"
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateCharacter()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Character>(new Character
            {
                Name = "綾波レイ",
                CHNName = "绫波丽",
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateSeries()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Series>(new Series
            {
                Name = "EVA系列 迷你陈列品手办～Q～feat.三月八日Vol.3",
                CHNName = "	エヴァンゲリオンシリーズ ミニディスプレイフィギュア～Q～feat.三月八日Vol.3",
                CompanyId = 1,
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
            List<FigureTag> figureTags  = new List<FigureTag>()
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
