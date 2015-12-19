using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

//Projet MN41
namespace Projet
{
    class Program
    {
        static int nn, ne, ligne;
        static string texte, FilePath;
        static double[,] G;
        static double[,] C;
        static double[,] T;
        static double[,] CL;
        static double[,] H;
        static double[] K;

        static void Main(string[] args)
        {
            int i, j;
            
            //LECTURE DU FICHIER TEXTE
            lecture_fichier();

            //CONSTRUCTION DES MATRICES ELEMENTAIRES
            
            //ASSEMBLAGE

            //SECOND MEMBRE

            //CONDITIONS AUX LIMITES

            //MATRICE REDUITE

            //RESOLUTION - Méthode de LU
        }

        static void lecture_fichier ()
        {
            int i, j;
            string texte;
            string FilePath = @"data.text";
            StreamReader fichier = new StreamReader(FilePath);

            //Nombre de noeuds
            fichier.ReadLine();
            int nn = new int();
            nn = Convert.ToInt32(fichier.ReadLine());
            double[,] G = new double[2 * nn, 2 * nn]; //Matrice globale

            //Coordonnees des noeuds
            fichier.ReadLine();
            fichier.ReadLine();
            double[,] C = new double[nn, 2];
            for (i = 0; i < nn; i++)
            {
                texte = fichier.ReadLine();
                string[] nums = texte.Split(' ');
                for (j = 0; j < 2; j++)
                {
                    C[i, j] = Convert.ToDouble(nums[j]);
                }
            }

            //Nombre elements
            fichier.ReadLine();
            fichier.ReadLine();
            int ne = new int();
            ne = Convert.ToInt32(fichier.ReadLine());

            //Raideurs
            fichier.ReadLine();
            fichier.ReadLine();
            double[] K = new double[ne];
            for (i = 0; i < ne; i++)
            {
                texte = fichier.ReadLine();
                string[] nums = texte.Split(' ');
                K[i] = Convert.ToDouble(nums[i]);
            }

            //Tableau de connexion
            fichier.ReadLine();
            fichier.ReadLine();
            double[,] T = new double[ne, 3];
            for (i = 0; i < ne; i++)
            {
                T[i,0]=i+1;
                texte = fichier.ReadLine();
                string[] nums = texte.Split(' ');
                for (j = 1; j < 3; j++)
                {
                    T[i, j] = Convert.ToDouble(nums[j]);
                }
            }

            //Force et angle
            fichier.ReadLine();
            fichier.ReadLine();
            double[,] V = new double[nn, 2];
            for (i = 0; i < nn; i++)
            {
                texte = fichier.ReadLine();
                string[] nums = texte.Split(' ');
                for (j = 0; j < 2; j++)
                {
                    V[i, j] = Convert.ToDouble(nums[j]);
                }
            }
            for (i = 0; i < nn; i++)
            {
                int ligne = new int();
                if (V[i, 0] != 0)
                {
                    ligne = i;
                }
            } // si jamais plusieurs forces ?

            //Conditions limites sur les nœuds
            fichier.ReadLine();
            fichier.ReadLine();
            double[,] CL = new double[nn, nn];
            for (i = 0; i < nn; i++)
            {
                texte = fichier.ReadLine();
                string[] nums = texte.Split(' ');
                for (j = 0; j < nn; j++)
                {
                    CL[i, j] = Convert.ToDouble(nums[j]);
                }
            }

            //Angles avec horizontale
            fichier.ReadLine();
            fichier.ReadLine();
            double[] W = new double[ne];
            for (i = 0; i < nn; i++)
            {
                texte = fichier.ReadLine();
                string[] nums = texte.Split(' ');
                W[i] = Convert.ToDouble(nums[i]);
            }
            double[,] H = new double[ne, 2];
            for (i = 0; i < ne; i++)
            {
                H[i, 1] = Math.Cos(W[i]);
                H[i, 2] = Math.Sin(W[i]);
            }
        }

        static void assemblage ()
        {
            int i, k, l, m, p, c;

            for (i=1;i< ne+1;i++)
            {
                for(k=0;k< nn;k++)
                {
                    for(p=0;p< nn;p++)
                    {
                        if(T[i,1]==k && T[i,2]==p)
                        {
                            m = 1;
                        }
                        else
                        {
                            m = 0;
                        }
                        switch (m)
                        {
                            case 0:
                                break;
                            case 1: //mettre les matrices elementaires dans la matrice globale



                                break;
                            default:
                                break;
                        }
                    }
                }
            }

        }
    }
}
