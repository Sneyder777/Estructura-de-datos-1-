using System;

class TallerCiclos
{
    static void Main()
    {
        Console.WriteLine("=== EJERCICIOS DE CICLOS EN C# ===\n");

        Console.WriteLine("EJERCICIO 1 – Números del 1 al 20 (solo pares)");
        for (int i = 1; i <= 20; i++)
            if (i % 2 == 0) Console.WriteLine(i);

        Console.WriteLine("\nEJERCICIO 2 – Contar positivos y negativos");
        int positivos = 0, negativos = 0, ceros = 0;
        for (int i = 1; i <= 10; i++)
        {
            Console.Write("Ingrese el número " + i + ": ");
            int num = int.Parse(Console.ReadLine());
            if (num > 0) positivos++;
            else if (num < 0) negativos++;
            else ceros++;
        }
        Console.WriteLine("Positivos: " + positivos + ", Negativos: " + negativos + ", Ceros: " + ceros);

        Console.WriteLine("\nEJERCICIO 3 – Suma de los primeros N números");
        Console.Write("Ingrese un número N: ");
        int N = int.Parse(Console.ReadLine());
        int suma = 0;
        for (int i = 1; i <= N; i++) suma += i;
        Console.WriteLine("Suma: " + suma);

        Console.WriteLine("\nEJERCICIO 4 – Suma hasta número negativo");
        int numPos, sumaPos = 0;
        do
        {
            Console.Write("Ingrese un número (negativo para terminar): ");
            numPos = int.Parse(Console.ReadLine());
            if (numPos >= 0) sumaPos += numPos;
        } while (numPos >= 0);
        Console.WriteLine("Suma de positivos: " + sumaPos);

        Console.WriteLine("\nEJERCICIO 5 – Promedio de notas");
        Console.Write("¿Cuántas notas desea ingresar?: ");
        int cantidad = int.Parse(Console.ReadLine());
        double sumaNotas = 0;
        for (int i = 1; i <= cantidad; i++)
        {
            Console.Write("Ingrese la nota " + i + ": ");
            double nota = double.Parse(Console.ReadLine());
            sumaNotas += nota;
        }
        double promedio = sumaNotas / cantidad;
        Console.WriteLine("Promedio: " + promedio);

        Console.WriteLine("\nEJERCICIO 6 – Contador de dígitos");
        Console.Write("Ingrese un número entero: ");
        int numero = int.Parse(Console.ReadLine());
        int digitos = 0;
        if (numero == 0) digitos = 1;
        else while (numero != 0) { numero /= 10; digitos++; }
        Console.WriteLine("El número tiene " + digitos + " dígitos.");

        Console.WriteLine("\nEJERCICIO 7 – Factorial de un número");
        Console.Write("Ingrese un número entero positivo: ");
        int n = int.Parse(Console.ReadLine());
        long factorial = 1;
        for (int i = 1; i <= n; i++) factorial *= i;
        Console.WriteLine("Factorial: " + factorial);

        Console.WriteLine("\nEJERCICIO 8 – Serie Fibonacci");
        Console.Write("¿Cuántos términos desea?: ");
        int F = int.Parse(Console.ReadLine());
        int a = 0, b = 1, c;
        for (int i = 1; i <= F; i++)
        {
            Console.Write(a + " ");
            c = a + b;
            a = b;
            b = c;
        }
        Console.WriteLine();

        Console.WriteLine("\nEJERCICIO 9 – Validar contraseña");
        string contraseña;
        do
        {
            Console.Write("Ingrese la contraseña: ");
            contraseña = Console.ReadLine();
            if (contraseña != "12345") Console.WriteLine("Contraseña incorrecta.");
        } while (contraseña != "12345");
        Console.WriteLine("¡Contraseña correcta!");

        Console.WriteLine("\nEJERCICIO 10 – Adivina el número");
        Random random = new Random();
        int secreto = random.Next(1, 51);
        int intento;
        do
        {
            Console.Write("Adivina el número (entre 1 y 50): ");
            intento = int.Parse(Console.ReadLine());
            if (intento < secreto) Console.WriteLine("El número secreto es mayor.");
            else if (intento > secreto) Console.WriteLine("El número secreto es menor.");
            else Console.WriteLine("¡Correcto! El número era " + secreto);
        } while (intento != secreto);
    }
}
