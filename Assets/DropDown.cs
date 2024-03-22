using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDown : MonoBehaviour
{
    public TMP_InputField output;
    public void HandleInputData(int val)
    {
        string grammarString = output.text;
        if (val == 0)
        {
            // Do nothing
            UnityEngine.Debug.Log("No grammar selected.");
        }
        if (val == 1)
        {
            // XYZ, Drift (0,0,0)
            grammarString = "[evaluations = {D = 5.715403245, P = 119.5345480, P_aux = 20.91445571, L_1 = .9521861810, R_1 = .9521861810, a_1 = .1666, b_1 = .1666, c_1 = .1666, c_2 = .1666, c_3 = .1666, c_4 = .1666}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(c_3,D),Prod(c_4,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D)), R_1 = Union(Prod(b_1,D)), a_1 = Atom, b_1 = Atom, c_1 = Atom, c_2 = Atom, c_3 = Atom, c_4 = Atom}, rho_approx = {.1666}, atomSet = {a_1 = [0, 0, 1], b_1 = [0, 0, -1], c_1 = [1, 0, 0], c_2 = [0, 1, 0], c_3 = [-1, 0, 0], c_4 = [0, -1, 0]}]";
        }
        if (val == 2)
        {
            // XYZ, Drift (-1,0,0)
            grammarString = "[evaluations = {D = 4.828427128, P = 16.48528138, P_aux = 3.414213563, L_1 = .7071067812, R_1 = 1.414213562, a_1 = .1464466094, b_1 = .1464466094, b_2 = .1464466094, c_1 = .1464466094, c_2 = .1464466094, c_3 = .1464466094, c_4 = .1464466094}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(c_3,D),Prod(c_4,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D)), a_1 = Atom, b_1 = Atom, b_2 = Atom, c_1 = Atom, c_2 = Atom, c_3 = Atom, c_4 = Atom}, rho_approx = {.1464466094}, atomSet = {a_1 = [1, 0, 0], b_1 = [-1, 0, 0], b_2 = [-1, 0, 0], c_1 = [0, 1, 0], c_2 = [0, 0, 1], c_3 = [0, -1, 0], c_4 = [0, 0, -1]}]";
        }
        if (val == 3)
        {
            // XYZ, Drift (0,-1,0)
            grammarString = "[evaluations = {D = 4.828427128, P = 16.48528138, P_aux = 3.414213563, L_1 = .7071067812, R_1 = 1.414213562, a_1 = .1464466094, b_1 = .1464466094, b_2 = .1464466094, c_1 = .1464466094, c_2 = .1464466094, c_3 = .1464466094, c_4 = .1464466094}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(c_3,D),Prod(c_4,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D)), a_1 = Atom, b_1 = Atom, b_2 = Atom, c_1 = Atom, c_2 = Atom, c_3 = Atom, c_4 = Atom}, rho_approx = {.1464466094}, atomSet = {a_1 = [0, 1, 0], b_1 = [0, -1, 0], b_2 = [0, -1, 0], c_1 = [1, 0, 0], c_2 = [0, 0, 1], c_3 = [-1, 0, 0], c_4 = [0, 0, -1]}]";
        }
        if (val == 4)
        {
            // XYZ, Drift (0,0,-1)
            grammarString = "[evaluations = {D = 4.828427128, P = 16.48528138, P_aux = 3.414213563, L_1 = .7071067812, R_1 = 1.414213562, a_1 = .1464466094, b_1 = .1464466094, b_2 = .1464466094, c_1 = .1464466094, c_2 = .1464466094, c_3 = .1464466094, c_4 = .1464466094}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(c_3,D),Prod(c_4,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D)), a_1 = Atom, b_1 = Atom, b_2 = Atom, c_1 = Atom, c_2 = Atom, c_3 = Atom, c_4 = Atom}, rho_approx = {.1464466094}, atomSet = {a_1 = [0, 0, 1], b_1 = [0, 0, -1], b_2 = [0, 0, -1], c_1 = [1, 0, 0], c_2 = [0, 1, 0], c_3 = [-1, 0, 0], c_4 = [0, -1, 0]}]";
        }
        if (val == 5)
        {
            // XYZ, Drift (-1,-1,0)
            grammarString = "[evaluations = {D = 2.707106780, P = 9.242640675, P_aux = 3.414213560, L_1 = .7071067810, R_1 = 1.414213562, a_1 = .1306019375, a_2 = .1306019375, b_1 = .1306019375, b_2 = .1306019375, b_3 = .1306019375, b_4 = .1306019375, c_1 = .1306019375, c_2 = .1306019375}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D),Prod(a_2,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D),Prod(b_3,D),Prod(b_4,D)), a_1 = Atom, a_2 = Atom, b_1 = Atom, b_2 = Atom, b_3 = Atom, b_4 = Atom, c_1 = Atom, c_2 = Atom}, rho_approx = {.1306019375}, atomSet = {a_1 = [1, 0, 0], a_2 = [0, 1, 0], b_1 = [-1, 0, 0], b_2 = [-1, 0, 0], b_3 = [0, -1, 0], b_4 = [0, -1, 0], c_1 = [0, 0, 1], c_2 = [0, 0, -1]}]";
        }
        if (val == 6)
        {
            // XYZ, Drift (-1,0,-1)
            grammarString = "[evaluations = {D = 2.707106780, P = 9.242640675, P_aux = 3.414213560, L_1 = .7071067810, R_1 = 1.414213562, a_1 = .1306019375, a_2 = .1306019375, b_1 = .1306019375, b_2 = .1306019375, b_3 = .1306019375, b_4 = .1306019375, c_1 = .1306019375, c_2 = .1306019375}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D),Prod(a_2,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D),Prod(b_3,D),Prod(b_4,D)), a_1 = Atom, a_2 = Atom, b_1 = Atom, b_2 = Atom, b_3 = Atom, b_4 = Atom, c_1 = Atom, c_2 = Atom}, rho_approx = {.1306019375}, atomSet = {a_1 = [1, 0, 0], a_2 = [0, 0, 1], b_1 = [-1, 0, 0], b_2 = [-1, 0, 0], b_3 = [0, 0, -1], b_4 = [0, 0, -1], c_1 = [0, 1, 0], c_2 = [0, -1, 0]}]";
        }
        if (val == 7)
        {
            // XYZ, Drift (0,-1,-1)
            grammarString = "[evaluations = {D = 2.707106780, P = 9.242640675, P_aux = 3.414213560, L_1 = .7071067810, R_1 = 1.414213562, a_1 = .1306019375, a_2 = .1306019375, b_1 = .1306019375, b_2 = .1306019375, b_3 = .1306019375, b_4 = .1306019375, c_1 = .1306019375, c_2 = .1306019375}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D),Prod(a_2,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D),Prod(b_3,D),Prod(b_4,D)), a_1 = Atom, a_2 = Atom, b_1 = Atom, b_2 = Atom, b_3 = Atom, b_4 = Atom, c_1 = Atom, c_2 = Atom}, rho_approx = {.1306019375}, atomSet = {a_1 = [0, 1, 0], a_2 = [0, 0, 1], b_1 = [0, -1, 0], b_2 = [0, -1, 0], b_3 = [0, 0, -1], b_4 = [0, 0, -1], c_1 = [1, 0, 0], c_2 = [-1, 0, 0]}]";
        }
        if (val == 8)
        {
            // XYZ, Drift (-1,-1,-1)
            grammarString = "[evaluations = {D = 2.000000000, P = 6.828427125, P_aux = 3.414213563, L_1 = .7071067812, R_1 = 1.414213562, a_1 = .1178511302, a_2 = .1178511302, a_3 = .1178511302, b_1 = .1178511302, b_2 = .1178511302, b_3 = .1178511302, b_4 = .1178511302, b_5 = .1178511302, b_6 = .1178511302}, grammar = {D = Union(Epsilon,Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D),Prod(a_2,D),Prod(a_3,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D),Prod(b_3,D),Prod(b_4,D),Prod(b_5,D),Prod(b_6,D)), a_1 = Atom, a_2 = Atom, a_3 = Atom, b_1 = Atom, b_2 = Atom, b_3 = Atom, b_4 = Atom, b_5 = Atom, b_6 = Atom}, rho_approx = {.1178511302}, atomSet = {a_1 = [1, 0, 0], a_2 = [0, 1, 0], a_3 = [0, 0, 1], b_1 = [-1, 0, 0], b_2 = [-1, 0, 0], b_3 = [0, -1, 0], b_4 = [0, -1, 0], b_5 = [0, 0, -1], b_6 = [0, 0, -1]}]";
        }
        if (val == 9)
        {
            // XY, Drift (0,0)
            grammarString = "[evaluations = {D = 3.844675125, P = 98.03921510, P_aux = 25.49999985, L_1 = .9607843135, R_1 = .9607843135, a_1 = .2499, b_1 = .2499, c_1 = .2499, c_2 = .2499}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D)), R_1 = Union(Prod(b_1,D)), a_1 = Atom, b_1 = Atom, c_1 = Atom, c_2 = Atom}, rho_approx = {.2499}, atomSet = {a_1 = [1, 0, 0], b_1 = [-1, 0, 0], c_1 = [0, 1, 0], c_2 = [0, -1, 0]}]";
        }
        if (val == 10)
        {
            // XY, Drift (-1,0)
            grammarString = "[evaluations = {D = 3.414213562, P = 11.65685424, P_aux = 3.414213560, L_1 = .7071067810, R_1 = 1.414213562, a_1 = .2071067812, b_1 = .2071067812, b_2 = .2071067812, c_1 = .2071067812, c_2 = .2071067812}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D)), a_1 = Atom, b_1 = Atom, b_2 = Atom, c_1 = Atom, c_2 = Atom}, rho_approx = {.2071067812}, atomSet = {a_1 = [1, 0, 0], b_1 = [-1, 0, 0], b_2 = [-1, 0, 0], c_1 = [0, 1, 0], c_2 = [0, -1, 0]}]";
        }
        if (val == 11)
        {
            // XY, Drift (0,-1)
            grammarString = "[evaluations = {D = 3.414213562, P = 11.65685424, P_aux = 3.414213560, L_1 = .7071067810, R_1 = 1.414213562, a_1 = .2071067812, b_1 = .2071067812, b_2 = .2071067812, c_1 = .2071067812, c_2 = .2071067812}, grammar = {D = Union(Epsilon,Prod(c_1,D),Prod(c_2,D),Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D)), a_1 = Atom, b_1 = Atom, b_2 = Atom, c_1 = Atom, c_2 = Atom}, rho_approx = {.2071067812}, atomSet = {a_1 = [0, 1, 0], b_1 = [0, -1, 0], b_2 = [0, -1, 0], c_1 = [1, 0, 0], c_2 = [-1, 0, 0]}]";
        }
        if (val == 12)
        {
            // XY, Drift (-1,-1)
            grammarString = "[evaluations = {D = 2.000000000, P = 6.828427125, P_aux = 3.414213561, L_1 = .7071067811, R_1 = 1.414213562, a_1 = .1767766953, a_2 = .1767766953, b_1 = .1767766953, b_2 = .1767766953, b_3 = .1767766953, b_4 = .1767766953}, grammar = {D = Union(Epsilon,Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux)), L_1 = Union(Prod(a_1,D),Prod(a_2,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D),Prod(b_3,D),Prod(b_4,D)), a_1 = Atom, a_2 = Atom, b_1 = Atom, b_2 = Atom, b_3 = Atom, b_4 = Atom}, rho_approx = {.1767766953}, atomSet = {a_1 = [1, 0, 0], a_2 = [0, 1, 0], b_1 = [-1, 0, 0], b_2 = [-1, 0, 0], b_3 = [0, -1, 0], b_4 = [0, -1, 0]}]";
        }
        if (val == 13)
        {
            // (X+1,Y+1,Z+1,X-0,Y-0,Z-1)
            grammarString = "[evaluations = {D = 1.06789931389696, P = 18.5926041166182, P_aux = 17.4104467290745, L_1 = .264925545154258, L_2 = .0336708936674621, L_3 = .131375110420409, L_4 = .512591670670542, R_1 = .256295835335271, a_1 = .24, a_2 = .24, a_3 = .24, b_1 = .24}, grammar = {D = Union(Epsilon,Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux),Prod(L_2,P_aux),Prod(L_3,P_aux),Prod(L_4,P_aux)), L_1 = Union(Prod(a_3,D),Prod(L_2,R_1)), L_2 = Union(Prod(L_3,R_1)), L_3 = Union(Prod(L_4,R_1)), L_4 = Union(Prod(a_1,D),Prod(a_2,D)), R_1 = Union(Prod(b_1,D)), a_1 = Atom, a_2 = Atom, a_3 = Atom, b_1 = Atom}, rho_approx = {.24}, atomSet = {a_1 = [1, 0, 0], a_2 = [0, 1, 0], a_3 = [0, 0, 1], b_1 = [0, 0, -1]}]";
        }
        if (val == 14)
        {
            // (X+1,Y+1,Z+1,X-0,Y-0,Z-2)
            grammarString = "[evaluations = {D = 1.10015693863565, P = 11.638807266369, P_aux = 10.5792245248235, L_1 = .239575720417962, L_2 = .073065896338746, L_3 = .174773859822308, L_4 = .418059636681548, R_1 = .418059636681548, a_1 = .19, a_2 = .19, a_3 = .19, b_1 = .19, b_2 = .19}, grammar = {D = Union(Epsilon,Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux),Prod(L_2,P_aux),Prod(L_3,P_aux),Prod(L_4,P_aux)), L_1 = Union(Prod(a_3,D),Prod(L_2,R_1)), L_2 = Union(Prod(L_3,R_1)), L_3 = Union(Prod(L_4,R_1)), L_4 = Union(Prod(a_1,D),Prod(a_2,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D)), a_1 = Atom, a_2 = Atom, a_3 = Atom, b_1 = Atom, b_2 = Atom}, rho_approx = {.19}, atomSet = {a_1 = [1, 0, 0], a_2 = [0, 1, 0], a_3 = [0, 0, 1], b_1 = [0, 0, -1], b_2 = [0, 0, -1]}]";
        }
        if (val == 15)
        {
            // (X+1,Y+1,Z+1,X-0,Y-0,Z-3)
            grammarString = "[evaluations = {D = 1.12907480691428, P = 11.4511023170286, P_aux = 10.1420226958423, L_1 = .238164775346472, L_2 = .106120821755984, L_3 = .19581080365187, L_4 = .361303938212571, R_1 = .541955907318857, a_1 = .16, a_2 = .16, a_3 = .16, b_1 = .16, b_2 = .16, b_3 = .16}, grammar = {D = Union(Epsilon,Prod(L_1,R_1)), P = Prod(D,P_aux), P_aux = Union(Epsilon,Prod(L_1,P_aux),Prod(L_2,P_aux),Prod(L_3,P_aux),Prod(L_4,P_aux)), L_1 = Union(Prod(a_3,D),Prod(L_2,R_1)), L_2 = Union(Prod(L_3,R_1)), L_3 = Union(Prod(L_4,R_1)), L_4 = Union(Prod(a_1,D),Prod(a_2,D)), R_1 = Union(Prod(b_1,D),Prod(b_2,D),Prod(b_3,D)), a_1 = Atom, a_2 = Atom, a_3 = Atom, b_1 = Atom, b_2 = Atom, b_3 = Atom}, rho_approx = {.16}, atomSet = {a_1 = [1, 0, 0], a_2 = [0, 1, 0], a_3 = [0, 0, 1], b_1 = [0, 0, -1], b_2 = [0, 0, -1], b_3 = [0, 0, -1]}]";
        }
        UnityEngine.Debug.Log("grammarString = " + grammarString);
        output.text = grammarString;
    }
    

}
