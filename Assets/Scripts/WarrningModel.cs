using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WarrningModel
{
    public Action Result { get; private set; }
    public string Context { get; private set; }

    public WarrningModel(string value, Action result = null) {
        this.Context = value;
        this.Result = result;
    }
}
