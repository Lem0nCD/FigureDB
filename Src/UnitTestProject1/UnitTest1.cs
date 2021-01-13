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
                    Name = "Ů"
                },
                new Tag()
                {
                    Color = "#2db7f5",
                    Name = "��"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "���Ա�"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "ȫ����"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "��Ʒ"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "����"
                },                
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "����"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "�ɶ�"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "ƴװ"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "����"
                },
                new Tag()
                {
                    Color = "#ED6FAC",
                    Name = "��е "
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
                CHNName = "����",
                Name = "����",
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
                Name = "�����o�������󥲥ꥪ��",
                CHNName = "�����͸���սʿ",
                About = "2000�꣬һ����ѧ̽�ն����ϼ�����Ա���������һʹͽ���ǵ��ġ���֮���ˡ�����̽�ա��ڶ�����нӴ�ʵ��ʱ������֮���ˡ��Ի٣��Ӷ������ˡ��ڶ��γ�������������������ս����������˿ڼ��룬����ƫת������ı䡣���ݶԡ��ڶ��γ�����ĵ��飬���Ϲ����ձ���������˹������о������� GEHIRN������EVA��ָ�����ˣ��ķ�չ�о�����GEHIRN�������˹������о����·����ֵľ޴�ն��������ܲ�����һ���棬���Ϲ�����������֯SEELEΪ��ʹ�����������ʼʵ�����ಹ��ƻ������ǽ������˵����㼯��һ��ͨ���к�ÿ���˵�AT������ʹÿ���˻ع�LCL֮����2004�꣬EVA���Ż�������������ʱ�����¹ʣ������õ�ĸ����Ψ��ʧ����Դ�ɿ�ʼִ�С���Դ�ɰ汾�����ಹ��ƻ�����2010�꣬GEHIRN���Ľ���NERV��2015�꿪ʼ������SEELE���ಹ��ƻ��籾�İ��ţ�һ�־����������ʹͽ����ʼ���ձ���½������NERV�ܲ�������NERV��֯EVA����ʹͽ����NERV��ʹͽ��ս��ͬʱ����Դ�����ܵ�ִ�����Լ��ļƻ�������ʱ�����ƣ���Դ�ɵļƻ��𽥱�SEELE���֣�NERV��SEELE������ì�ܲ����϶񻯡�Director's Cut�汾�ĵ�21��24���ɾ糡�桶Death��ƪ�������ɣ���¼��20��������������С�"
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateCharacter()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Character>(new Character
            {
                Name = "�c���쥤",
                CHNName = "籲���",
            });
            context.SaveChanges();
        }
        [TestMethod]
        public async Task CreateSeries()
        {
            var context = new MainContext(CreateDbContextOptions(constr));
            context.Add<Series>(new Series
            {
                Name = "EVAϵ�� �������Ʒ�ְ졫Q��feat.���°���Vol.3",
                CHNName = "	�������󥲥ꥪ�󥷥�`�� �ߥ˥ǥ����ץ쥤�ե����奢��Q��feat.���°���Vol.3",
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
                    Name = "����Ԫ��",
                    CHNName = "����Ԫ��",
                },
                new Artist()
                {
                    Name = "���°���",
                    CHNName = "���°���",
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
                    Name = "ԭ��",
                },
                new Job()
                {
                    Name = "ԭ��",
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
                CHNName = "EVAϵ�� �������Ʒ�ְ졫Q��feat.���°���Vol.3 ������EVA �������",
                Dimensions = 0,
                ManufacturerId = 1,
                Materials = "PVC, ABS",
                Name = "�������󥲥ꥪ�󥷥�`�� �ߥ˥ǥ����ץ쥤�ե����奢��Q��feat.���°���Vol.3 �����o�������󥲥ꥪ�� ��ǥߥ���",
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
                Content = "EVAϵ�� �������Ʒ�ְ졫Q��feat.���°���Vol.3 ������EVA 籲���",
                Title = "��Ŀ����",
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
