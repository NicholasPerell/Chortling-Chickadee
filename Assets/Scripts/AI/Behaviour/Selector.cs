using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Selector : Node
{
    protected List<Node> _nodes = new List<Node>();

    public Selector(List<Node> _nodes)
    {
        this._nodes = _nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (var node in _nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;
                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;
                case NodeState.FAILURE:
                    break;
                default:
                    break;
            }
        }
        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}
