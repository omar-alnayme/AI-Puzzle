using Puzzel_project;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form_Puzzle_application;


namespace PuzzleSolver
{
    public class BDBFS_Class
    {
        public List<string[,]> NodeChildeList = new List<string[,]>();
        private LinkedList<string[,]> nodesClosed= new LinkedList<string[,]>();
        public TimeSpan starttime {get; set;}
        public List<nodes_info> nodeInfoList = new List<nodes_info>(); 

        /// <summary>
        /// Get Depth of Breadth first search
        /// </summary>
        /// <param name="Goale"></param>
        /// <param name="State"></param>
        /// <param name="maxDepth"></param>
        /// <param name="SearchType"></param>
        /// <returns></returns>
        public SendBackInfo DBFS ( string[,] Goale, string[,] State, int maxDepth, string SearchType )
        {
            LinkedList<Qsearch_Obj> Qsearch = new LinkedList<Qsearch_Obj>();
            Qsearch_Obj Qsearchobj;
            starttime = DateTime.Now.TimeOfDay;
            SendBackInfo _sendbackInfo = new SendBackInfo();
            _sendbackInfo.SoloutionFound = false;
            int Depth = 1;
            NodeChildeList = getNodeChildren(State);
            nodesClosed.AddFirst(State);
            foreach (var sublist in NodeChildeList)
            {
                Qsearchobj = new Qsearch_Obj();
                Qsearchobj.Qnode = sublist;
                Qsearchobj.depth = Depth;
                Qsearch.AddLast(Qsearchobj);
            }
            nodes_info NodeInfoObj = new nodes_info();
            NodeInfoObj.node_parent = State;
            NodeInfoObj.depth = Depth;
            NodeInfoObj.node_childrens = new List<string[,]>(NodeChildeList);
            nodeInfoList.Add(NodeInfoObj);
            Boolean loopThrough = true;
            Boolean solutionFound = false;
            while (loopThrough)
            {
                NodeChildeList.Clear();
                if (Qsearch.Count <= 0)
                    break;
                Depth = Qsearch.First.Value.depth + 1;
                while (Depth > maxDepth)
                {
                    Qsearch.RemoveFirst();
                    if (Qsearch.Count > 0)
                        Depth = Qsearch.First.Value.depth + 1;
                    else
                        break;
                }
                if (Qsearch.Count <= 0)
                    break;
                var currentParentnode = Qsearch.First.Value;
                Qsearch.RemoveFirst();
                NodeChildeList = getNodeChildren(currentParentnode.Qnode);
                nodesClosed.AddFirst(currentParentnode.Qnode);
                NodeInfoObj = new nodes_info();
                NodeInfoObj.node_parent = currentParentnode.Qnode;
                NodeInfoObj.depth = Depth;
                NodeInfoObj.node_childrens = new List<string[,]>(NodeChildeList);
                nodeInfoList.Add(NodeInfoObj);
                if (SearchType == "DFS")
                {
                    NodeChildeList.Reverse();
                }
                foreach (var Node in NodeChildeList)
                {
                    Boolean AddRecord = true;
                    if (SearchType == "DFS")
                    {
                        foreach (var node in Qsearch)
                        {
                            if (ISitTheSame(Node, node.Qnode))
                            {
                                AddRecord = false;
                            }
                        }
                        foreach (var node in nodesClosed.Take(100).ToList())
                        {
                            if (ISitTheSame(Node, node))
                            {
                                AddRecord = false;
                            }
                        }
                        if (AddRecord)
                        {
                            Qsearchobj = new Qsearch_Obj();
                            Qsearchobj.Qnode = Node;
                            Qsearchobj.depth = Depth;
                            Qsearch.AddFirst(Qsearchobj);
                            nodesClosed.AddFirst(Node);
                        }
                    }
                    if (SearchType == "BFS")
                    {
                        foreach (var node in nodesClosed.Take(1000).ToList() )
                        {
                            if (ISitTheSame(Node, node))
                            {
                                AddRecord = false;
                            }
                        }
                        if (AddRecord)
                        {
                            Qsearchobj = new Qsearch_Obj();
                            Qsearchobj.Qnode = Node;
                            Qsearchobj.depth = Depth;
                            Qsearch.AddLast(Qsearchobj);
                            nodesClosed.AddFirst(Node);
                        }
                    }
                    if (ISitTheSame(Node,Goale))
                    {
                        solutionFound = true;  
                        break;
                    }
                }
                if (solutionFound)
                {
                    break;
                }
            }
            if (solutionFound)
            {
                _sendbackInfo.SoloutionFound = true;
                _sendbackInfo.ListNodesInfo = nodeInfoList;
            }
            else
            {
                _sendbackInfo.SoloutionFound = false;
                _sendbackInfo.ListNodesInfo = nodeInfoList;
            }
            TimeSpan Endtime = DateTime.Now.TimeOfDay;
            int totalnodes = 0;
            foreach (var x in nodeInfoList)
            {
                totalnodes = totalnodes + x.node_childrens.Count;
            }
            _sendbackInfo.depth = Depth.ToString();
            _sendbackInfo.startTime = starttime.ToString();
            _sendbackInfo.endTime = Endtime.ToString();
            _sendbackInfo.Qleft = Qsearch.Count.ToString();
            _sendbackInfo.totalParents = nodeInfoList.Count.ToString();
            _sendbackInfo.totalNodes = totalnodes.ToString();
            _sendbackInfo.totalTimeinMS = (Endtime - starttime).TotalMilliseconds.ToString();
            _sendbackInfo.SearchType = SearchType;
            SaveToFile_Class.savetofile(nodeInfoList);
            return _sendbackInfo;
        }

        /// <summary>
        /// Best First search
        /// </summary>
        /// <param name="Goale"></param>
        /// <param name="State"></param>
        /// <param name="maxDepth"></param>
        /// <param name="SearchType"></param>
        /// <returns></returns>
        public SendBackInfo BestFS ( string[,] Goale, string[,] State )
        {
            LinkedList<bestQsearch_Obj> Qsearch = new LinkedList<bestQsearch_Obj>();
            bestQsearch_Obj Qsearchobj;
            starttime = DateTime.Now.TimeOfDay;
            SendBackInfo _sendbackInfo = new SendBackInfo();
            _sendbackInfo.SoloutionFound = false;
            int Depth = 1;
            NodeChildeList = getNodeChildren(State);
            nodesClosed.AddFirst(State);
            foreach (var sublist in NodeChildeList)
            {
                Qsearchobj = new bestQsearch_Obj();
                Qsearchobj.Qnode = sublist;
                Qsearchobj.depth = Depth;
                Qsearchobj.H = GetStepsToPostionANDTileInWrongPlace(sublist,Goale);
                Qsearchobj.HplusDepth= GetStepsToPostionANDTileInWrongPlace(sublist, Goale);
                Qsearch.AddLast(Qsearchobj);
            }
            nodes_info NodeInfoObj = new nodes_info();
            NodeInfoObj.node_parent = State;
            NodeInfoObj.depth = Depth;
            NodeInfoObj.node_childrens = new List<string[,]>(NodeChildeList);
            nodeInfoList.Add(NodeInfoObj);
            Boolean loopThrough = true;
            Boolean SolutionFound = false;
            while (loopThrough)
            {
                LinkedList<bestQsearch_Obj> x =new LinkedList<bestQsearch_Obj>(Qsearch.OrderBy (i => i.HplusDepth));
                Qsearch = x;
                NodeChildeList.Clear();
endOfTheLoopNew:;
                Depth = Qsearch.First.Value.depth + 1;
                if (Qsearch.Count <= 0)
                    break;
                var currentParentnode = Qsearch.First.Value;
                Qsearch.RemoveFirst();
                foreach (var ClosedNode in nodesClosed)
                {
                    if (ISitTheSame(ClosedNode,currentParentnode.Qnode))
                    {
                        goto endOfTheLoopNew;
                    }
                }
                NodeChildeList = getNodeChildren(currentParentnode.Qnode);
                NodeInfoObj = new nodes_info();
                NodeInfoObj.node_parent = currentParentnode.Qnode;
                NodeInfoObj.depth = Depth;
                NodeInfoObj.node_childrens = new List<string[,]>(NodeChildeList);
                nodeInfoList.Add(NodeInfoObj);
                nodesClosed.AddFirst(currentParentnode.Qnode);
                foreach (var sublist in NodeChildeList)
                {
                        Qsearchobj = new bestQsearch_Obj();
                        Qsearchobj.Qnode = sublist;
                        Qsearchobj.depth = Depth;
                        Qsearchobj.H = GetStepsToPostionANDTileInWrongPlace(sublist, Goale);
                        Qsearchobj.HplusDepth =  GetStepsToPostionANDTileInWrongPlace(sublist, Goale);
                        Qsearch.AddLast(Qsearchobj);
                    if (ISitTheSame(sublist, Goale))
                    {
                        SolutionFound = true;
                        break;
                    }
                }
                if (SolutionFound)
                {
                    break;
                }
            }
            if (SolutionFound)
            {
                _sendbackInfo.SoloutionFound = true;
                _sendbackInfo.ListNodesInfo = nodeInfoList;
            }
            else
            {
                _sendbackInfo.SoloutionFound = false;
                _sendbackInfo.ListNodesInfo = nodeInfoList;
            }
            TimeSpan Endtime = DateTime.Now.TimeOfDay;
            int totalnodes = 0;
            foreach (var x in nodeInfoList)
            {
                totalnodes = totalnodes + x.node_childrens.Count;
            }
            _sendbackInfo.depth = Depth.ToString();
            _sendbackInfo.startTime = starttime.ToString();
            _sendbackInfo.endTime = Endtime.ToString();
            _sendbackInfo.Qleft = Qsearch.Count.ToString();
            _sendbackInfo.totalParents = nodeInfoList.Count.ToString();
            _sendbackInfo.totalNodes = totalnodes.ToString();
            _sendbackInfo.totalTimeinMS = (Endtime - starttime).TotalMilliseconds.ToString();
            _sendbackInfo.SearchType = "Best First Search";
            SaveToFile_Class.savetofile(nodeInfoList);
            return _sendbackInfo;
        }

        /// <summary>
        /// create child nodes from the passsed node
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private List<string[,]> getNodeChildren ( string[,] parentNode )
        {
            List<string[,]> NodeChildrens = new List<string[,]>(); 
            int leng = parentNode.GetLength(0);
            obj_location Location= Service_Class.GetLocationOfEmpty(parentNode);
            if (Location.i!=0 && Location.i != leng-1)
            {
                if (Location.j == 0)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,])parentNode.Clone();

                    NodeChildrens.Add (_MovePuzzel("1", _child)); 
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("2", _child)); 
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("3", _child));
                    return NodeChildrens;
                }
            }
            if (Location.i == 0)
            {
                if (Location.j == 0)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,])parentNode.Clone();

                    NodeChildrens.Add(_MovePuzzel("2", _child));
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("3", _child));
                    return NodeChildrens;
                }
            }
            if (Location.i == leng-1)
            {
                if (Location.j == 0)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("1", _child));
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("2", _child)); 
                    return NodeChildrens;
                }
            }
            if (Location.i != 0 && Location.i != leng - 1)
            {
                if (Location.j == leng - 1)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,])parentNode.Clone();

                    NodeChildrens.Add(_MovePuzzel("0", _child)); 
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("1", _child)); 
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("3", _child)); 
                    return NodeChildrens;
                }
            }
            if (Location.i == 0)
            {
                if (Location.j == leng - 1)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,])parentNode.Clone();

                    NodeChildrens.Add(_MovePuzzel("0", _child));
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("3", _child));
                    return NodeChildrens;
                }
            }
            if (Location.i == leng-1)
            {
                if (Location.j == leng - 1)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,]) parentNode.Clone();

                    NodeChildrens.Add( _MovePuzzel("0", _child));

                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("1", _child));

                    return NodeChildrens;
                }
            }
            if (Location.i == leng - 1 )
            {
                if (Location.j < leng - 1 && Location.j!=0)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,])parentNode.Clone();

                    NodeChildrens.Add(_MovePuzzel("0", _child));
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("1", _child)); 
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("2", _child));
                    return NodeChildrens;
                }
            }
            if (Location.i < leng - 1 && Location.i !=0)
            {
                if (Location.j < leng - 1 && Location.j != 0)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("0", _child)); 
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("1", _child)); 
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("2", _child));
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("3", _child)); 
                    return NodeChildrens;
                }
            }
            if (Location.i ==0)
            {
                if (Location.j < leng - 1 && Location.j != 0)
                {
                    string[,] _child = new string[leng - 1, leng - 1];
                    _child = (string[,])parentNode.Clone();

                    NodeChildrens.Add(_MovePuzzel("0", _child));
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("2", _child)); 
                    _child = (string[,])parentNode.Clone();
                    NodeChildrens.Add(_MovePuzzel("3", _child)); 
                    return NodeChildrens;
                }
            }


            return null;
        }

        private string[,] _MovePuzzel ( string input, string[,] PUZ )
        {
            obj_location location = new obj_location();
            location = Service_Class.GetLocationOfEmpty(PUZ);
            if (input == "0")
            {
                string temp = PUZ[location.i, location.j - 1];
                PUZ[location.i, location.j - 1] = PUZ[location.i, location.j];
                PUZ[location.i, location.j] = temp;
                return PUZ;
            }
            if (input == "1")
            {
                string temp = PUZ[location.i - 1, location.j];
                PUZ[location.i - 1, location.j] = PUZ[location.i, location.j];
                PUZ[location.i, location.j] = temp;
                
                return PUZ;
            }
            if (input == "2")
            {
                string temp = PUZ[location.i, location.j + 1];
                PUZ[location.i, location.j + 1] = PUZ[location.i, location.j];
                PUZ[location.i, location.j] = temp;
                return PUZ;
            }
            if (input == "3")
            {
                string temp = PUZ[location.i + 1, location.j];
                PUZ[location.i + 1, location.j] = PUZ[location.i, location.j];
                PUZ[location.i, location.j] = temp;
                return PUZ;
            }
            return null;
        }

        private int GetStepsToPostionANDTileInWrongPlace ( string[,] node, string[,] goal )
        {
            int NumberOfMissplaced = 0;
            int len = node.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (node[i, j] != goal[i, j])
                    {
                        NumberOfMissplaced += 1;
                    }
                }
            }
            int steps = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (node[i, j] != goal[i, j])
                    {
                        for (int n = 0; n < len; n++)
                        {
                            for (int m = 0; m < len; m++)
                            {
                                if (node[n, m] == goal[i, j])
                                {
                                    steps = steps+ ((n - i) *-1) + ((m - j)*-1);
                                }
                            }
                        }
                    }
                }
            }
            return steps + NumberOfMissplaced;
        }

        private bool ISitTheSame ( string[,] a, string[,] b )
        {
            int NumberOfMissplaced = 0;
            int len = a.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        NumberOfMissplaced += 1;
                    }
                }
            }
            if (NumberOfMissplaced > 0)
                return false;
            else
                return true;

        }
    }

    public class SendBackInfo
    {
        public List<nodes_info> ListNodesInfo { get; set; }
        public Boolean SoloutionFound { get; set; }
        public string depth { get; set; }
        public string Qleft { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string totalTimeinMS { get; set; }
        public string totalParents { get; set; }
        public string totalNodes { get; set; }
        public string SearchType { get; set; }
    }

    public class nodes_info
    {
        public string[,] node_parent { get; set; }
        public List<string[,]> node_childrens {get; set;}
        public int depth { get; set; }
       
    }

    public class Qsearch_Obj
    {
        public string[,] Qnode;
        public int depth { get; set; }
    }

    #region Best first search

    //-----------------------------------------
    // Best first search 
    //-----------------------------------------
    public class BestNodes_info
    {
        public string[,] node_parent { get; set; }
        public List<BestNodeChildrens> node_childrens { get; set; }
        public int depth { get; set; }
        public int H { get; set; }
        public int HplusDepth { get; set; }
    }

    public class BestNodeChildrens
    {
        public string[,] node_childerns { get; set; }
        public int H { get; set; }
        public int depth { get; set; }
        public int HplusDepth { get; set; }
    }
    public class bestQsearch_Obj
    {
        public string[,] Qnode;
        public int depth { get; set; }
        public int H { get; set; }
        public int HplusDepth { get; set; }
    }
    #endregion
}
