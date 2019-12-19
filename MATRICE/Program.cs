using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Dynamic;

namespace Matrice
{
    class Program
    {
        static void Main(string[] args)
        {
           // AM CITIT UNDEVA CA NU SE POATE FACE OVERRIDE LA OPERATORUL + INTR-O CLASA GENERICA ASA CA AM FACUT DOAR METODE PENTRU ADUNARE , SCADERE SI INMULTIRE

            Matrix<int> matrix = new Matrix<int>(new int[0, 0]);
            matrix = matrix.GetMatrix();

            Matrix<int> matrix1 = new Matrix<int>(new int[0, 0]);
            matrix1 = matrix1.GetMatrix();

            Matrix<int>.Multiplication(matrix, matrix1);
            
            

            Console.ReadLine();
        }
        


    }

    public class Matrix<T> 
    {
        
        public T[,] matrice;
        public Matrix(T[,] matrita) 
        {
            this.matrice = matrita;
        }
        
        public T this[int row,int col]
        {
            get { return matrice[row, col]; }
            set { matrice[row, col] =  value; }
        }
        

        public Matrix<T> GetMatrix()
        {
            int rows, cols;
            Console.WriteLine("insert nr of rows:");
            rows = int.Parse(Console.ReadLine());
            Console.WriteLine("insert nr of cols:");
            cols = int.Parse(Console.ReadLine());

            Matrix<T> matrix = new Matrix<T>(new T[rows, cols]);

            Console.WriteLine("insert matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = (T)Convert.ChangeType(Console.ReadLine(), typeof (T));
                }
            }
            Console.WriteLine("matrix:");
            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            return matrix;
        }

       

        public static Matrix<T> Add( Matrix<T> a, Matrix<T> b)
        {

            Matrix<T> matrix = new Matrix<T>(new T[a.matrice.GetLength(0),a.matrice.GetLength(1)]);
            dynamic m1 = a;
            dynamic m2 = b;
            dynamic m3 = matrix;
            for (int i = 0; i < a.matrice.GetLength(0); i++)
            {
                for (int j = 0; j < a.matrice.GetLength(1); j++)
                {
                     m3[i, j] = m1[i, j] + m2[i, j];
                }
            }
            Console.WriteLine("Sum of matrices is:");
            for (int i = 0; i < a.matrice.GetLength(0); i++)
            {

                for (int j = 0; j < a.matrice.GetLength(1); j++)
                {
                    Console.Write($"{m3[i, j]} ");
                }
                Console.WriteLine();
            }
            return m3;
        }

        public static Matrix<T> Subtract(Matrix<T> a, Matrix<T> b)
        {

            Matrix<T> matrix = new Matrix<T>(new T[a.matrice.GetLength(0), a.matrice.GetLength(1)]);
            dynamic m1 = a;
            dynamic m2 = b;
            dynamic m3 = matrix;
            for (int i = 0; i < a.matrice.GetLength(0); i++)
            {
                for (int j = 0; j < a.matrice.GetLength(1); j++)
                {
                    m3[i, j] = m1[i, j] - m2[i, j];
                }
            }
            Console.WriteLine("Subtract of matrices is:");
            for (int i = 0; i < a.matrice.GetLength(0); i++)
            {

                for (int j = 0; j < a.matrice.GetLength(1); j++)
                {
                    Console.Write($"{m3[i, j]} ");
                }
                Console.WriteLine();
            }
            return m3;
        }
        public static Matrix<T> Multiplication(Matrix<T> a, Matrix<T> b)
        {

            Matrix<T> matrix = new Matrix<T>(new T[a.matrice.GetLength(0), a.matrice.GetLength(1)]);
            dynamic m1 = a;
            dynamic m2 = b;
            dynamic m3 = matrix;
            try
            {
                
                for (int i = 0; i < a.matrice.GetLength(0); i++)
                {
                    for (int j = 0; j < a.matrice.GetLength(1); j++)
                    {
                        if(m1[i,j] == 0 || m2[i,j] == 0)
                        {
                            throw new Exception("Invald number '0' for multiplication");
                        }
                        else
                        {
                            m3[i, j] = m1[i, j] * m2[i, j];
                        }
                       
                    }
                }
                
                Console.WriteLine("Multiplication of matrices is:");
                for (int i = 0; i < a.matrice.GetLength(0); i++)
                {

                    for (int j = 0; j < a.matrice.GetLength(1); j++)
                    {
                        Console.Write($"{m3[i, j]} ");
                    }
                    Console.WriteLine();
                }
               
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            return m3;
        }

    }


}
