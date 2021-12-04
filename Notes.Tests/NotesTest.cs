using Moq;
using Notes.Application.Services;
using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;
using NUnit.Framework;

namespace Notes.Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateNote_ShouldReturnTrue()
        {
            //arrange

            var note = new Note()
            {
                Title = "Test title",
                Text = "123",
                Hashtags = new System.Collections.Generic.HashSet<string>()
            };

            note.Hashtags.Add("123");
            note.Hashtags.Add("123");
            note.Hashtags.Add("123");
            note.Hashtags.Add("123");

            var NoteRepositoryMoq = new Mock<INoteRepository>();
            NoteRepositoryMoq.Setup(x => x.Add(note)).Verifiable();


            var service = new NoteService(NoteRepositoryMoq.Object);

            //act

            var result = service.Create(note);

            //assert

            NoteRepositoryMoq.Verify(x => x.Add(note), Times.Once);
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateNote_ShouldReturnFalse()
        {
            //arrange

            var note = new Note()
            {
                Title = null,
                Text = "123",
                Hashtags = new System.Collections.Generic.HashSet<string>()
            };

            note.Hashtags.Add("123");
            note.Hashtags.Add("123");
            note.Hashtags.Add("123");
            note.Hashtags.Add("123");

            var NoteRepositoryMoq = new Mock<INoteRepository>();
            NoteRepositoryMoq.Setup(x => x.Add(note)).Verifiable();


            var service = new NoteService(NoteRepositoryMoq.Object);

            //act

            var result = service.Create(note);

            //assert

            NoteRepositoryMoq.Verify(x => x.Add(note), Times.Never);
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase((uint)1)]
        public void GetNoteById_ShouldReturnTrue(uint id)
        {
            //arrange

            var expectedNote = new Note()
            {
                Title = "qwe",
                Text = "saddas",
                Hashtags = new System.Collections.Generic.HashSet<string>()
                {
                    {"wqe"},{"zxc"}
                }
            };

            var NoteRepositoryMoq = new Mock<INoteRepository>();
            NoteRepositoryMoq.Setup(x => x.GetById(It.Is<uint>(x => x == id)))
                .Returns(new Note()
                {
                    Title = "qwe",
                    Text = "saddas",
                    Hashtags = new System.Collections.Generic.HashSet<string>()
                    {
                        {"wqe"},{"zxc"}
                    }
                }).Verifiable();


            var service = new NoteService(NoteRepositoryMoq.Object);

            //act

            var result = service.GetById(id);

            //assert

            NoteRepositoryMoq.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNote.Title, result.Title);
            Assert.AreEqual(expectedNote.Text, result.Text);
            Assert.AreEqual(expectedNote.Hashtags, result.Hashtags);
        }

        [Test]
        [TestCase((uint)2)]
        public void GetNoteById_ShouldReturnFalse(uint id)
        {
            //arrange

            var expectedNote = new Note()
            {
                Title = "qwe",
                Text = "saddas",
                Hashtags = new System.Collections.Generic.HashSet<string>()
                {
                    {"wqe"},{"zxc"}
                }
            };

            var NoteRepositoryMoq = new Mock<INoteRepository>();
            NoteRepositoryMoq.Setup(x => x.GetById(It.Is<uint>(x => x == id)))
                .Returns(new Note()
                {
                    Title = "qwe",
                    Text = "saddas",
                    Hashtags = new System.Collections.Generic.HashSet<string>()
                    {
                        {"wqe"},{"zxc"}
                    }
                }).Verifiable();


            var service = new NoteService(NoteRepositoryMoq.Object);

            //act

            var result = service.GetById(id + 1);

            //assert

            NoteRepositoryMoq.Verify(x => x.GetById(id), Times.Never);
            Assert.IsNull(result);
            Assert.AreNotSame(expectedNote, result);
        }


        [Test]
        [TestCase("1")]
        public void GetByTitle_ShouldReturnTwoNotes(string title)
        {
            //arrange
            var expectedNotes = new Note[]
            {
                new Note
                {
                    Title = "1",
                    Text = "text1",
                    Hashtags = new System.Collections.Generic.HashSet<string>()
                    {
                        {"wqe"},{"zxc"}
                    }
                },
                new Note
                {
                    Title = "1",
                    Text = "text2",
                    Hashtags = new System.Collections.Generic.HashSet<string>()
                    {
                        {"sad"},{"asd"},{"ddasdasdasda"}
                    }
                }
            };


            var NotesRepositoryMoq = new Mock<INoteRepository>();

            NotesRepositoryMoq.Setup(x => x.GetByTitle(It.Is<string>(x => x == title)))
                .Returns(() => new Note[]
                {
                    new Note
                    {
                        Title = "1",
                        Text = "text1",
                        Hashtags = new System.Collections.Generic.HashSet<string>()
                        {
                            {"wqe"},{"zxc"}
                        }

                    },
                    new Note
                    {
                        Title = "1",
                        Text = "text2",
                        Hashtags = new System.Collections.Generic.HashSet<string>()
                        {
                            {"sad"},{"asd"},{"ddasdasdasda"}
                        }
                    }

                }).Verifiable();

            var service = new NoteService(NotesRepositoryMoq.Object);

            //act

            var result = service.GetByTitle(title);

            //assert

            NotesRepositoryMoq.Verify(x => x.GetByTitle(title), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNotes[0].Title, result[0].Title);
            Assert.AreEqual(expectedNotes[0].Text, result[0].Text);
            Assert.AreEqual(expectedNotes[0].Hashtags, result[0].Hashtags);
            Assert.AreEqual(expectedNotes[1].Title, result[1].Title);
            Assert.AreEqual(expectedNotes[1].Text, result[1].Text);
            Assert.AreEqual(expectedNotes[1].Hashtags, result[1].Hashtags);
        }

        [Test]
        [TestCase("1","2")]
        public void GetByTitle_ShouldReturnFalse(string title, string expectedTitle)
        {
            //arrange

            var NotesRepositoryMoq = new Mock<INoteRepository>();

            NotesRepositoryMoq.Setup(x => x.GetByTitle(It.Is<string>(x => x == title)))
                .Returns(() => new Note[]
                {
                    new Note
                    {
                        Title = "1",
                        Text = "text1",
                        Hashtags = new System.Collections.Generic.HashSet<string>()
                        {
                            {"wqe"},{"zxc"}
                        }

                    },
                    new Note
                    {
                        Title = "1",
                        Text = "text2",
                        Hashtags = new System.Collections.Generic.HashSet<string>()
                        {
                            {"sad"},{"asd"},{"ddasdasdasda"}
                        }
                    }

                }).Verifiable();

            var service = new NoteService(NotesRepositoryMoq.Object);

            //act

            var result = service.GetByTitle(title);

            //assert

            NotesRepositoryMoq.Verify(x => x.GetByTitle(title), Times.Once);
            Assert.AreNotEqual(expectedTitle, result[0].Title);
            Assert.AreNotEqual(expectedTitle, result[1].Title);

        }

        [Test]
        [TestCase("")]
        public void GetByTitle_ShouldReturnNull(string title)
        {
            //arrange
            var noteTitle = "sadsad";

            var NotesRepositoryMoq = new Mock<INoteRepository>();

            NotesRepositoryMoq.Setup(x => x.GetByTitle(It.Is<string>(x => x == noteTitle)))
                .Returns(() => new Note[]
                {
                    new Note
                    {
                        Title = noteTitle,
                        Text = "text1",
                        Hashtags = new System.Collections.Generic.HashSet<string>()
                        {
                            {"wqe"},{"zxc"}
                        }

                    },
                    new Note
                    {
                        Title = noteTitle,
                        Text = "text2",
                        Hashtags = new System.Collections.Generic.HashSet<string>()
                        {
                            {"sad"},{"asd"},{"ddasdasdasda"}
                        }
                    }

                }).Verifiable();

            var service = new NoteService(NotesRepositoryMoq.Object);

            //act

            var result = service.GetByTitle(title);

            //assert

            NotesRepositoryMoq.Verify(x => x.GetByTitle(title), Times.Once);
            Assert.IsEmpty(result);

        }

    }
}