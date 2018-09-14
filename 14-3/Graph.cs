using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_3
{
    class Graph
    {
        private readonly int MAX_VERTS = 20;
        private readonly int INFINITY = 1000000;
        private Vertex[] vertexList;
        private int nVerts;
        private int[,] adjMat;
        public Graph()
        {
            adjMat = new int[MAX_VERTS, MAX_VERTS];
            vertexList = new Vertex[MAX_VERTS];
            nVerts = 0;
            for (int i = 0; i < MAX_VERTS; i++)
                for (int j = 0; j < MAX_VERTS; j++)
                    adjMat[i, j] = INFINITY;
        }
        public void addVertex(char lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }
        public void addEdge(int start, int end, int weight)
        {
            adjMat[start, end] = weight;
        }
        public void algFloyd()
        {
            for (int i = 0; i < nVerts; i++)
            {
                for (int j = 0; j < nVerts; j++)
                {
                    if (adjMat[i, j] < INFINITY)
                    {
                        for (int k = 0; k < nVerts; k++)
                        {
                            int temp = adjMat[k, i] + adjMat[i, j];
                            if (adjMat[k, j] > temp)
                                adjMat[k, j] = temp;
                        }
                    }
                }
            }
        }
        public void displayPaths()
        {
            for (int i = 0; i < nVerts; i++)
                Console.Write("	" + vertexList[i].lable);

            Console.WriteLine();
            for (int j = 0; j < nVerts; j++) // display contents of sPath[]
            {
                Console.Write(vertexList[j].lable);
                for (int i = 0; i < nVerts; i++)
                {
                    int temp = adjMat[j, i];
                    if (temp != INFINITY)
                        Console.Write("	" + adjMat[j, i]);
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
