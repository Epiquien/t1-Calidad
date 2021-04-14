using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using t1calidad;

namespace BolosServiceTest
{
    [TestFixture]

    public class BolosTests
    {
        BolosService bolosService;

        [SetUp]

        public void SetUpGame()
        {
            bolosService = new BolosService();
        }
         void CantidadRodadas(int lanzar, int pinos)
        {
            

            for (int i = 0; i < lanzar; i++)
            {
                bolosService.Caida(pinos);
            }

        }


        [Test]

        public void RuedaPrimerJuego()
        {

           // var bolosService = new BolosService();
            CantidadRodadas(20,0);

           // Assert.AreEqual(bolosService.Puntaje(), Is.EqualTo(0));
            Assert.That(bolosService.Puntaje(), Is.EqualTo(0));

        }

        [Test]

        public void UnaRodada()
        {
           // var bolosService = new BolosService();

            CantidadRodadas(20, 1); //Una en todas

          
            Assert.That(bolosService.Puntaje(), Is.EqualTo(20));
        }

        [Test]

        public void RuedaFramaPrimerJuego()
        {
           // var bolosService = new BolosService();

            bolosService.Caida(9);
            bolosService.Caida(1);
            CantidadRodadas(18, 1);  // una en todas 
            // 18 + 11 = 29

            Assert.That(bolosService.Puntaje(), Is.EqualTo(29));
            
        }

        [Test]

        public void RodadaTodoFrame()
        {
            var bolosService = new BolosService();
            CantidadRodadas(21,5); 

            Assert.That(bolosService.Puntaje(), Is.EqualTo(150));

        }

        [Test]
        public void RodadaNueveUnaSpares()
        {
            
            var bolosService = new BolosService();
            for (int i = 0; i < 10; i++)
            {
                bolosService.Caida(9);
                bolosService.Caida(1);

               
            }
            bolosService.Caida(9);

            Assert.That(bolosService.Puntaje(), Is.EqualTo(190));
           


        }

        [Test]

        public void RodadaJuegoPerfecto()
        {
            var bolosService = new BolosService();
            CantidadRodadas(12,10);

            Assert.That(bolosService.Puntaje(), Is.EqualTo(300));

        }

        [Test]
        public void TypicalGame()
        {
            var bolosService = new BolosService();
            bolosService.Caida(10);
            bolosService.Caida(9); bolosService.Caida(10);
            bolosService.Caida(5); bolosService.Caida(5);
            bolosService.Caida(7); bolosService.Caida(2);
            bolosService.Caida(10);
            bolosService.Caida(10);
            bolosService.Caida(10);
            bolosService.Caida(9); bolosService.Caida(0);
            bolosService.Caida(8); bolosService.Caida(2);
            bolosService.Caida(9); bolosService.Caida(1); bolosService.Caida(10);

            Assert.That(bolosService.Puntaje(), Is.EqualTo(187));

        }
    }
}
