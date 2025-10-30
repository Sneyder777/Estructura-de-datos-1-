// TALLER DE LISTAS EN C#
// Brayan Sneyder García Camacho
// 30 ejercicios sobre listas enlazadas, productos,
// listas circulares y listas simuladas con arreglos.

using System;
using System.Collections.Generic;

namespace TallerListasBrayan
{
    // Nodo para listas de enteros
    public class Nodo
    {
        public int Valor;
        public Nodo Siguiente;
        public Nodo(int valor) { Valor = valor; Siguiente = null; }
    }

    // Producto para ejercicios de inventario
    public class Producto
    {
        public int Id;
        public string Nombre;
        public double Precio;
        public Producto Siguiente;
        public Producto(int id, string nombre, double precio) { Id = id; Nombre = nombre; Precio = precio; Siguiente = null; }
        public override string ToString() => $"Id:{Id}, Nombre:{Nombre}, Precio:{Precio}";
    }

    // Implementacion basica de lista enlazada de enteros
    public class ListaEnlazada
    {
        public Nodo Cabeza;
        public ListaEnlazada() { Cabeza = null; }
        public void AgregarAlFinal(int valor)
        {
            Nodo nuevo = new Nodo(valor);
            if (Cabeza == null) { Cabeza = nuevo; return; }
            Nodo t = Cabeza; while (t.Siguiente != null) t = t.Siguiente; t.Siguiente = nuevo;
        }
        public void ImprimirLista()
        {
            Nodo t = Cabeza;
            Console.Write("Lista: ");
            while (t != null) { Console.Write(t.Valor + (t.Siguiente != null ? " -> " : "")); t = t.Siguiente; }
            Console.WriteLine();
        }
        public int ContarNodos() { int cont = 0; Nodo t = Cabeza; while (t != null) { cont++; t = t.Siguiente; } return cont; }
        public bool Buscar(int valor) { Nodo t = Cabeza; while (t != null) { if (t.Valor == valor) return true; t = t.Siguiente; } return false; }
        public Nodo ObtenerUltimoNodo() { if (Cabeza == null) return null; Nodo t = Cabeza; while (t.Siguiente != null) t = t.Siguiente; return t; }
        public int SumarValores() { int s = 0; Nodo t = Cabeza; while (t != null) { s += t.Valor; t = t.Siguiente; } return s; }
        public int? EncontrarMaximo() { if (Cabeza == null) return null; int max = Cabeza.Valor; Nodo t = Cabeza.Siguiente; while (t != null) { if (t.Valor > max) max = t.Valor; t = t.Siguiente; } return max; }
        public int[] ConvertirAArreglo() { int n = ContarNodos(); int[] arr = new int[n]; Nodo t = Cabeza; int i = 0; while (t != null) { arr[i++] = t.Valor; t = t.Siguiente; } return arr; }
        public void Invertir() { Nodo prev = null, curr = Cabeza; while (curr != null) { Nodo next = curr.Siguiente; curr.Siguiente = prev; prev = curr; curr = next; } Cabeza = prev; }
        public bool InsertarEnPosicion(int valor, int posicion)
        {
            if (posicion < 0) return false;
            Nodo nuevo = new Nodo(valor);
            if (posicion == 0) { nuevo.Siguiente = Cabeza; Cabeza = nuevo; return true; }
            Nodo t = Cabeza; int idx = 0; while (t != null && idx < posicion - 1) { t = t.Siguiente; idx++; }
            if (t == null) return false; nuevo.Siguiente = t.Siguiente; t.Siguiente = nuevo; return true;
        }
        public bool EliminarDePosicion(int posicion)
        {
            if (Cabeza == null || posicion < 0) return false;
            if (posicion == 0) { Cabeza = Cabeza.Siguiente; return true; }
            Nodo t = Cabeza; int idx = 0; while (t != null && idx < posicion - 1) { t = t.Siguiente; idx++; }
            if (t == null || t.Siguiente == null) return false; t.Siguiente = t.Siguiente.Siguiente; return true;
        }
        public Nodo EncontrarNodoMedio() { if (Cabeza == null) return null; Nodo lento = Cabeza, rapido = Cabeza; while (rapido != null && rapido.Siguiente != null) { lento = lento.Siguiente; rapido = rapido.Siguiente.Siguiente; } return lento; }
        public void EliminarDuplicadosOrdenados() { Nodo t = Cabeza; while (t != null && t.Siguiente != null) { if (t.Valor == t.Siguiente.Valor) t.Siguiente = t.Siguiente.Siguiente; else t = t.Siguiente; } }
        public bool TieneCiclo() { Nodo tortuga = Cabeza, liebre = Cabeza; while (liebre != null && liebre.Siguiente != null) { tortuga = tortuga.Siguiente; liebre = liebre.Siguiente.Siguiente; if (tortuga == liebre) return true; } return false; }
        public void EliminarNesimoDesdeFinal(int n)
        {
            Nodo dummy = new Nodo(0) { Siguiente = Cabeza }; Nodo fast = dummy, slow = dummy;
            for (int i = 0; i < n + 1; i++) { if (fast == null) return; fast = fast.Siguiente; }
            while (fast != null) { fast = fast.Siguiente; slow = slow.Siguiente; }
            if (slow.Siguiente != null) slow.Siguiente = slow.Siguiente.Siguiente; Cabeza = dummy.Siguiente;
        }
        public void SepararParesImpares()
        {
            Nodo dummyPar = new Nodo(0), dummyImpar = new Nodo(0); Nodo tailPar = dummyPar, tailImpar = dummyImpar; Nodo t = Cabeza;
            while (t != null) { if (t.Valor % 2 == 0) { tailPar.Siguiente = t; tailPar = tailPar.Siguiente; } else { tailImpar.Siguiente = t; tailImpar = tailImpar.Siguiente; } t = t.Siguiente; }
            tailImpar.Siguiente = null; tailPar.Siguiente = dummyImpar.Siguiente; Cabeza = dummyPar.Siguiente;
        }
    }

    // Lista de productos (ejercicios 7-12)
    public class ListaProductos
    {
        public Producto Cabeza;
        public ListaProductos() { Cabeza = null; }
        public void AgregarProducto(Producto p) { if (Cabeza == null) { Cabeza = p; return; } Producto t = Cabeza; while (t.Siguiente != null) t = t.Siguiente; t.Siguiente = p; }
        public void InsertarProductoOrdenado(Producto nuevoProducto) { if (Cabeza == null || nuevoProducto.Precio < Cabeza.Precio) { nuevoProducto.Siguiente = Cabeza; Cabeza = nuevoProducto; return; } Producto t = Cabeza; while (t.Siguiente != null && t.Siguiente.Precio <= nuevoProducto.Precio) t = t.Siguiente; nuevoProducto.Siguiente = t.Siguiente; t.Siguiente = nuevoProducto; }
        public Producto BuscarPorId(int id) { Producto t = Cabeza; while (t != null) { if (t.Id == id) return t; t = t.Siguiente; } return null; }
        public bool ActualizarPrecio(int id, double nuevoPrecio) { Producto p = BuscarPorId(id); if (p == null) return false; p.Precio = nuevoPrecio; return true; }
        public int EliminarPorNombre(string nombre) { int eliminados = 0; while (Cabeza != null && Cabeza.Nombre == nombre) { Cabeza = Cabeza.Siguiente; eliminados++; } if (Cabeza == null) return eliminados; Producto prev = Cabeza; Producto curr = Cabeza.Siguiente; while (curr != null) { if (curr.Nombre == nombre) { prev.Siguiente = curr.Siguiente; eliminados++; curr = prev.Siguiente; } else { prev = curr; curr = curr.Siguiente; } } return eliminados; }
        public List<string> ObtenerNombres() { List<string> res = new List<string>(); Producto t = Cabeza; while (t != null) { res.Add(t.Nombre); t = t.Siguiente; } return res; }
        public double CalcularValorTotal() { double total = 0; Producto t = Cabeza; while (t != null) { total += t.Precio; t = t.Siguiente; } return total; }
        public void ImprimirProductos() { Producto t = Cabeza; Console.WriteLine("Lista de productos:"); while (t != null) { Console.WriteLine("  " + t); t = t.Siguiente; } }
    }

    // Lista circular (ejercicios 17-21)
    public class ListaCircular
    {
        public Nodo Cabeza;
        public ListaCircular() { Cabeza = null; }
        public void InsertarAlFinalCircular(int valor) { Nodo nuevo = new Nodo(valor); if (Cabeza == null) { Cabeza = nuevo; Cabeza.Siguiente = Cabeza; return; } Nodo t = Cabeza; while (t.Siguiente != Cabeza) t = t.Siguiente; t.Siguiente = nuevo; nuevo.Siguiente = Cabeza; }
        public static bool EsCircular(Nodo cabeza) { if (cabeza == null) return false; Nodo t = cabeza.Siguiente; while (t != null && t != cabeza) t = t.Siguiente; return t == cabeza; }
        public int ContarNodosCirculares() { if (Cabeza == null) return 0; int cont = 1; Nodo t = Cabeza.Siguiente; while (t != Cabeza) { cont++; t = t.Siguiente; } return cont; }
        public void EliminarCabezaCircular() { if (Cabeza == null) return; if (Cabeza.Siguiente == Cabeza) { Cabeza = null; return; } Nodo ultimo = Cabeza; while (ultimo.Siguiente != Cabeza) ultimo = ultimo.Siguiente; Cabeza = Cabeza.Siguiente; ultimo.Siguiente = Cabeza; }
        public void Rotar(int pasos) { if (Cabeza == null || pasos <= 0) return; for (int i = 0; i < pasos; i++) Cabeza = Cabeza.Siguiente; }
        public void ImprimirUnaVuelta() { if (Cabeza == null) { Console.WriteLine("Lista circular vacía."); return; } Nodo t = Cabeza; Console.Write("Circular: "); do { Console.Write(t.Valor + (t.Siguiente != Cabeza ? " -> " : "")); t = t.Siguiente; } while (t != Cabeza); Console.WriteLine(); }
    }

    // Lista enlazada simulada con arreglos (ejercicios 13-16)
    public class ListaEnlazadaArray
    {
        private int[] valores; private int[] siguiente; private bool[] libre; private int cabeza; private int disponible;
        public ListaEnlazadaArray(int capacidad)
        {
            valores = new int[capacidad]; siguiente = new int[capacidad]; libre = new bool[capacidad];
            for (int i = 0; i < capacidad; i++) { libre[i] = true; siguiente[i] = -1; }
            cabeza = -1; disponible = 0;
            for (int i = 0; i < capacidad - 1; i++) siguiente[i] = i + 1;
            if (capacidad > 0) siguiente[capacidad - 1] = -1;
        }
        private int ObtenerIndiceLibre() { if (disponible == -1) return -1; int idx = disponible; disponible = siguiente[disponible]; libre[idx] = false; siguiente[idx] = -1; return idx; }
        private void LiberarIndice(int idx) { libre[idx] = true; siguiente[idx] = disponible; disponible = idx; }
        public bool InsertarAlInicio(int valor) { int idx = ObtenerIndiceLibre(); if (idx == -1) return false; valores[idx] = valor; siguiente[idx] = cabeza; cabeza = idx; return true; }
        public bool EliminarPorValor(int valor) { int prev = -1; int curr = cabeza; while (curr != -1) { if (valores[curr] == valor) { if (prev == -1) cabeza = siguiente[curr]; else siguiente[prev] = siguiente[curr]; LiberarIndice(curr); return true; } prev = curr; curr = siguiente[curr]; } return false; }
        public void ImprimirLista() { Console.Write("Lista (array): "); int t = cabeza; while (t != -1) { Console.Write(valores[t] + (siguiente[t] != -1 ? " -> " : "")); t = siguiente[t]; } Console.WriteLine(); }
        public void Desfragmentar()
        {
            int n = valores.Length; int[] nuevosValores = new int[n]; int[] nuevosSiguiente = new int[n]; bool[] nuevosLibre = new bool[n];
            for (int i = 0; i < n; i++) { nuevosSiguiente[i] = -1; nuevosLibre[i] = true; }
            int nuevoIdx = 0; int t = cabeza; int prevNuevo = -1;
            while (t != -1)
            {
                nuevosValores[nuevoIdx] = valores[t]; nuevosLibre[nuevoIdx] = false;
                if (prevNuevo != -1) nuevosSiguiente[prevNuevo] = nuevoIdx;
                prevNuevo = nuevoIdx; nuevoIdx++; t = siguiente[t];
            }
            for (int i = nuevoIdx; i < n - 1; i++) nuevosSiguiente[i] = i + 1;
            if (n > 0) nuevosSiguiente[n - 1] = -1;
            valores = nuevosValores; siguiente = nuevosSiguiente; libre = nuevosLibre; cabeza = (nuevoIdx > 0) ? 0 : -1; disponible = (nuevoIdx < n) ? nuevoIdx : -1;
        }
    }

    // Utilidades para listas
    public static class UtilidadesListas
    {
        public static Nodo FusionarListasOrdenadas(Nodo cabeza1, Nodo cabeza2)
        {
            Nodo dummy = new Nodo(0); Nodo tail = dummy; Nodo a = cabeza1, b = cabeza2;
            while (a != null && b != null)
            {
                if (a.Valor <= b.Valor) { tail.Siguiente = a; a = a.Siguiente; }
                else { tail.Siguiente = b; b = b.Siguiente; }
                tail = tail.Siguiente;
            }
            tail.Siguiente = (a != null) ? a : b;
            return dummy.Siguiente;
        }
    }

    // Programa principal: ejecuta los 30 ejercicios automáticamente (1..30)
    class Program
    {
        static void Main(string[] args)
        {
            // EJERCICIO 1
            // Cuenta nodos de una lista enlazada.
            Console.WriteLine("EJERCICIO 1: Contar nodos en una lista enlazada");
            {
                ListaEnlazada l = new ListaEnlazada();
                l.AgregarAlFinal(5); l.AgregarAlFinal(10); l.AgregarAlFinal(15);
                l.ImprimirLista();
                Console.WriteLine("Salida: " + l.ContarNodos() + " (esperado: 3)");
            }

            // EJERCICIO 2
            // Buscar un valor en la lista (true/false).
            Console.WriteLine("EJERCICIO 2: Buscar un valor en la lista");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(1); l.AgregarAlFinal(2); l.AgregarAlFinal(3);
                l.ImprimirLista();
                Console.WriteLine("Buscar 2 -> " + l.Buscar(2) + " (esperado: True)");
                Console.WriteLine("Buscar 5 -> " + l.Buscar(5) + " (esperado: False)");
            }

            // EJERCICIO 3
            // Obtener el ultimo nodo y mostrar su valor.
            Console.WriteLine("EJERCICIO 3: Obtener ultimo nodo");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(7); l.AgregarAlFinal(8); l.AgregarAlFinal(9);
                l.ImprimirLista();
                Nodo ultimo = l.ObtenerUltimoNodo();
                Console.WriteLine("ultimo nodo: " + (ultimo != null ? ultimo.Valor.ToString() : "null") + " (esperado: 9)");
            }

            // EJERCICIO 4
            // Sumar todos los valores de la lista.
            Console.WriteLine("EJERCICIO 4: Sumar todos los valores");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(2); l.AgregarAlFinal(3); l.AgregarAlFinal(5);
                l.ImprimirLista();
                Console.WriteLine("Suma: " + l.SumarValores() + " (esperado: 10)");
            }

            // EJERCICIO 5
            // Encontrar el valor máximo en la lista.
            Console.WriteLine("EJERCICIO 5: Encontrar valor máximo");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(-1); l.AgregarAlFinal(0); l.AgregarAlFinal(100);
                l.ImprimirLista();
                var max = l.EncontrarMaximo();
                Console.WriteLine("Máximo: " + (max.HasValue ? max.Value.ToString() : "Lista vacia") + " (esperado: 100)");
            }

            // EJERCICIO 6
            // Convertir la lista a un arreglo y mostrarlo.
            Console.WriteLine("EJERCICIO 6: Convertir a arreglo");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(4); l.AgregarAlFinal(5); l.AgregarAlFinal(6);
                l.ImprimirLista();
                int[] arr = l.ConvertirAArreglo();
                Console.WriteLine("Arreglo: [" + string.Join(", ", arr) + "] (esperado: [4, 5, 6])");
            }

            // EJERCICIO 7
            // Insertar producto manteniendo orden por precio.
            Console.WriteLine("EJERCICIO 7: Insertar producto ordenado por precio");
            {
                ListaProductos lp = new ListaProductos();
                lp.AgregarProducto(new Producto(1, "A", 15.0));
                lp.AgregarProducto(new Producto(2, "B", 25.0));
                lp.AgregarProducto(new Producto(3, "C", 35.0));
                Console.WriteLine("Antes:");
                lp.ImprimirProductos();
                Console.WriteLine("Insertando producto D precio 20...");
                lp.InsertarProductoOrdenado(new Producto(4, "D", 20.0));
                Console.WriteLine("Después:");
                lp.ImprimirProductos();
            }

            // EJERCICIO 8
            // Buscar producto por Id y mostrar resultado.
            Console.WriteLine("EJERCICIO 8: Buscar producto por Id");
            {
                ListaProductos lp = new ListaProductos(); lp.AgregarProducto(new Producto(10, "Lap", 1000)); lp.AgregarProducto(new Producto(11, "Mouse", 50));
                var p = lp.BuscarPorId(11);
                Console.WriteLine("Resultado: " + (p != null ? p.ToString() : "null") + " (esperado: Mouse)");
            }

            // EJERCICIO 9
            Console.WriteLine("EJERCICIO 9: Actualizar precio de producto");
            {
                ListaProductos lp = new ListaProductos(); lp.AgregarProducto(new Producto(5, "X", 10));
                Console.WriteLine("Antes:"); lp.ImprimirProductos();
                bool ok = lp.ActualizarPrecio(5, 20.5);
                Console.WriteLine($"Actualizado: {ok} (esperado: True)");
                Console.WriteLine("Despues:"); lp.ImprimirProductos();
            }

            // EJERCICIO 10
            Console.WriteLine("EJERCICIO 10: Eliminar productos por nombre");
            {
                ListaProductos lp = new ListaProductos();
                lp.AgregarProducto(new Producto(1, "P", 10)); lp.AgregarProducto(new Producto(2, "Q", 20)); lp.AgregarProducto(new Producto(3, "P", 30));
                Console.WriteLine("Antes:"); lp.ImprimirProductos();
                int eliminados = lp.EliminarPorNombre("P");
                Console.WriteLine($"Eliminados: {eliminados} (esperado: 2)");
                Console.WriteLine("Despues:"); lp.ImprimirProductos();
            }

            // EJERCICIO 11
            Console.WriteLine("EJERCICIO 11: Obtener nombres de productos");
            {
                ListaProductos lp = new ListaProductos(); lp.AgregarProducto(new Producto(1, "PP", 10)); lp.AgregarProducto(new Producto(2, "QQ", 20));
                var nombres = lp.ObtenerNombres();
                Console.WriteLine("Nombres: " + string.Join(", ", nombres) + " (esperado: PP, QQ)");
            }

            // EJERCICIO 12
            Console.WriteLine("EJERCICIO 12: Calcular valor total del inventario");
            {
                ListaProductos lp = new ListaProductos(); lp.AgregarProducto(new Producto(1, "A", 10)); lp.AgregarProducto(new Producto(2, "B", 20));
                Console.WriteLine("Total: " + lp.CalcularValorTotal() + " (esperado: 30)");
            }

            // EJERCICIO 13
            Console.WriteLine("EJERCICIO 13: Insertar al inicio en ListaEnlazadaArray");
            {
                ListaEnlazadaArray arr = new ListaEnlazadaArray(5);
                arr.InsertarAlInicio(10); arr.InsertarAlInicio(20); arr.InsertarAlInicio(30);
                arr.ImprimirLista();
                Console.WriteLine("Salida esperada: 30 -> 20 -> 10");
            }

            // EJERCICIO 14
            Console.WriteLine("EJERCICIO 14: Eliminar por valor en ListaEnlazadaArray");
            {
                ListaEnlazadaArray arr = new ListaEnlazadaArray(5);
                arr.InsertarAlInicio(1); arr.InsertarAlInicio(2); arr.InsertarAlInicio(3);
                arr.ImprimirLista();
                bool ok14 = arr.EliminarPorValor(2);
                Console.WriteLine("Eliminó 2? " + ok14 + " (esperado: True)");
                arr.ImprimirLista();
            }

            // EJERCICIO 15
            Console.WriteLine("EJERCICIO 15: Imprimir lista (array)");
            {
                ListaEnlazadaArray arr = new ListaEnlazadaArray(4); arr.InsertarAlInicio(7); arr.InsertarAlInicio(8); arr.ImprimirLista();
            }

            // EJERCICIO 16
            Console.WriteLine("EJERCICIO 16: Desfragmentar lista en arreglo");
            {
                ListaEnlazadaArray arr = new ListaEnlazadaArray(6); arr.InsertarAlInicio(1); arr.InsertarAlInicio(2); arr.InsertarAlInicio(3);
                arr.ImprimirLista();
                Console.WriteLine("Desfragmentando...");
                arr.Desfragmentar();
                arr.ImprimirLista();
            }

            // EJERCICIO 17
            Console.WriteLine("EJERCICIO 17: Verificar si una lista es circular");
            {
                Nodo a = new Nodo(1); Nodo b = new Nodo(2); Nodo c = new Nodo(3); a.Siguiente = b; b.Siguiente = c; c.Siguiente = a;
                Console.WriteLine("Es circular? " + ListaCircular.EsCircular(a) + " (esperado: True)");
                Nodo x = new Nodo(5); x.Siguiente = new Nodo(6); Console.WriteLine("Es circular? " + ListaCircular.EsCircular(x) + " (esperado: False)");
            }

            // EJERCICIO 18
            Console.WriteLine("EJERCICIO 18: Contar nodos en lista circular");
            {
                ListaCircular lc = new ListaCircular(); lc.InsertarAlFinalCircular(1); lc.InsertarAlFinalCircular(2); lc.InsertarAlFinalCircular(3);
                lc.ImprimirUnaVuelta(); Console.WriteLine("Contados: " + lc.ContarNodosCirculares() + " (esperado: 3)");
            }

            // EJERCICIO 19
            Console.WriteLine("EJERCICIO 19: Insertar al final en lista circular");
            {
                ListaCircular lc = new ListaCircular(); lc.InsertarAlFinalCircular(10); lc.InsertarAlFinalCircular(20); lc.InsertarAlFinalCircular(30);
                lc.ImprimirUnaVuelta();
            }

            // EJERCICIO 20
            Console.WriteLine("EJERCICIO 20: Eliminar la cabeza de una lista circular");
            {
                ListaCircular lc = new ListaCircular(); lc.InsertarAlFinalCircular(100); lc.InsertarAlFinalCircular(200); lc.InsertarAlFinalCircular(300);
                lc.ImprimirUnaVuelta(); lc.EliminarCabezaCircular(); Console.WriteLine("Después de eliminar cabeza:"); lc.ImprimirUnaVuelta();
            }

            // EJERCICIO 21
            Console.WriteLine("EJERCICIO 21: Rotar la lista circular");
            {
                ListaCircular lc = new ListaCircular(); lc.InsertarAlFinalCircular(1); lc.InsertarAlFinalCircular(2); lc.InsertarAlFinalCircular(3); lc.InsertarAlFinalCircular(4);
                Console.WriteLine("Original:"); lc.ImprimirUnaVuelta(); lc.Rotar(1); Console.WriteLine("Rotada 1 paso:"); lc.ImprimirUnaVuelta(); lc.Rotar(2); Console.WriteLine("Rotada 2 pasos adicionales:"); lc.ImprimirUnaVuelta();
            }

            // EJERCICIO 22
            Console.WriteLine("EJERCICIO 22: Invertir una lista enlazada");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(1); l.AgregarAlFinal(2); l.AgregarAlFinal(3);
                Console.WriteLine("Antes:"); l.ImprimirLista(); l.Invertir(); Console.WriteLine("Despues (invertida):"); l.ImprimirLista();
            }

            // EJERCICIO 23
            Console.WriteLine("EJERCICIO 23: Insertar en posicion especifica");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(10); l.AgregarAlFinal(20); l.AgregarAlFinal(30);
                Console.WriteLine("Antes:"); l.ImprimirLista(); bool ok23 = l.InsertarEnPosicion(15, 1); Console.WriteLine("Inserto en pos 1? " + ok23 + " (esperado: True)"); l.ImprimirLista();
            }

            // EJERCICIO 24
            Console.WriteLine("EJERCICIO 24: Eliminar en posicion especifica");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(5); l.AgregarAlFinal(6); l.AgregarAlFinal(7);
                Console.WriteLine("Antes:"); l.ImprimirLista(); bool ok24 = l.EliminarDePosicion(1); Console.WriteLine("Elimino pos 1? " + ok24 + " (esperado: True)");'' l.ImprimirLista();
            }

            // EJERCICIO 25
            Console.WriteLine("EJERCICIO 25: Encontrar nodo medio");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(1); l.AgregarAlFinal(2); l.AgregarAlFinal(3); l.AgregarAlFinal(4);
                l.ImprimirLista(); Nodo medio = l.EncontrarNodoMedio(); Console.WriteLine("Nodo medio: " + (medio != null ? medio.Valor.ToString() : "null") + " (esperado: 3)");
            }

            // EJERCICIO 26
            Console.WriteLine("EJERCICIO 26: Eliminar duplicados (lista ordenada)");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(1); l.AgregarAlFinal(1); l.AgregarAlFinal(2); l.AgregarAlFinal(3); l.AgregarAlFinal(3);
                Console.WriteLine("Antes:"); l.ImprimirLista(); l.EliminarDuplicadosOrdenados(); Console.WriteLine("Despues:"); l.ImprimirLista();
            }

            // EJERCICIO 27
            Console.WriteLine("EJERCICIO 27: Fusionar dos listas ordenadas");
            {
                ListaEnlazada a = new ListaEnlazada(); a.AgregarAlFinal(1); a.AgregarAlFinal(3); a.AgregarAlFinal(5);
                ListaEnlazada b = new ListaEnlazada(); b.AgregarAlFinal(2); b.AgregarAlFinal(4); b.AgregarAlFinal(6);
                Console.WriteLine("Lista A:"); a.ImprimirLista(); Console.WriteLine("Lista B:"); b.ImprimirLista();
                Nodo fusion = UtilidadesListas.FusionarListasOrdenadas(a.Cabeza, b.Cabeza);
                Console.Write("Lista fusionada: "); Nodo t = fusion; while (t != null) { Console.Write(t.Valor + (t.Siguiente != null ? " -> " : "")); t = t.Siguiente; } Console.WriteLine();
            }

            // EJERCICIO 28
            Console.WriteLine("EJERCICIO 28: Detectar ciclo en lista");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(1); l.AgregarAlFinal(2); l.AgregarAlFinal(3);
                Nodo tx = l.Cabeza; while (tx.Siguiente != null) tx = tx.Siguiente; tx.Siguiente = l.Cabeza.Siguiente; // crea ciclo
                Console.WriteLine("Detectar ciclo? " + l.TieneCiclo() + " (esperado: True)");
            }

            // EJERCICIO 29
            Console.WriteLine("EJERCICIO 29: Eliminar n-ésimo nodo desde el final");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(10); l.AgregarAlFinal(20); l.AgregarAlFinal(30); l.AgregarAlFinal(40);
                Console.WriteLine("Antes:"); l.ImprimirLista(); l.EliminarNesimoDesdeFinal(2); Console.WriteLine("Después (se elimina 30):"); l.ImprimirLista();
            }

            // EJERCICIO 30
            Console.WriteLine("EJERCICIO 30: Separar pares e impares manteniendo orden relativo");
            {
                ListaEnlazada l = new ListaEnlazada(); l.AgregarAlFinal(1); l.AgregarAlFinal(2); l.AgregarAlFinal(3); l.AgregarAlFinal(4); l.AgregarAlFinal(5);
                Console.WriteLine("Antes:"); l.ImprimirLista(); l.SepararParesImpares(); Console.WriteLine("Después:"); l.ImprimirLista();
            }

            // Mensaje final
            Console.WriteLine("=== FIN DEL TALLER DE LISTAS EN C# ===");
        }
    }
}
