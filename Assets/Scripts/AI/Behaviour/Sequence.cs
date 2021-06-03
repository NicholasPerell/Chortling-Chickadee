using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sequence : Node
{
    protected List<Node> _nodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this._nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;
        foreach (var node in _nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    isAnyNodeRunning = true;
                    break;
                case NodeState.SUCCESS:
                    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                default:
                    break;
            }
        }

        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return _nodeState;
    }
}
