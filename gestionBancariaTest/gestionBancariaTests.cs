using Microsoft.VisualStudio.TestTools.UnitTesting;
using gestionBancariaApp;
using System;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {
        [TestMethod]
        public void RealizarIngreso_Valido()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 500;
            double saldoEsperado = 1500;
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarIngreso(ingreso);

            // Afirmación de la prueba (valor esperado Vs. Valor obtenido)
            double saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo de la cuenta no es correcto");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RealizarIngreso_CantidadNegativa()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = -500; // Ingreso negativo para provocar la excepción
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarIngreso(ingreso);
        }

        [TestMethod]
        public void RealizarIngreso_LimiteInferior()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 0; // Ingreso igual a cero
            double saldoEsperado = saldoInicial; // El saldo no debe cambiar
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarIngreso(ingreso);

            // Afirmación de la prueba (valor esperado Vs. Valor obtenido)
            double saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo de la cuenta no es correcto");
        }

        [TestMethod]
        public void RealizarReintegro_Valido()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 500;
            double saldoEsperado = 500;
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarReintegro(reintegro);

            // Afirmación de la prueba (valor esperado Vs. Valor obtenido)
            double saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo de la cuenta no es correcto");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RealizarReintegro_CantidadNegativa()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = -500; // Reintegro negativo para provocar la excepción
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarReintegro(reintegro);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RealizarReintegro_SaldoInsuficiente()
        {
            // Preparación del caso de prueba
            double saldoInicial = 100;
            double reintegro = 500; // Reintegro mayor que el saldo para provocar la excepción
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarReintegro(reintegro);
        }

        [TestMethod]
        public void RealizarReintegro_LimiteSuperior()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = saldoInicial; // Reintegro igual al saldo
            double saldoEsperado = 0; // El saldo debe reducirse a cero
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarReintegro(reintegro);

            // Afirmación de la prueba (valor esperado Vs. Valor obtenido)
            double saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo de la cuenta no es correcto");
        }
    }
}
