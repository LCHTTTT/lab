using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quanjujingtai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        controlmove.z = 0;
        lzpz.ResetSharedState();
        jqpguding.jqpflag = 0;
        jqpguding.jqpwater = 0;
        lzpz.pzjs = 0;
        lzpz.jg = 0;
        mhguding.mhflag = 0;
        mhguding.move = 0;
        mkguding.mkflag = 0;
        ScreenPointToRay_ts.gzflag = 0;
        szpz.szflag = 0;
        xuanniu.xnflag = 0;
        yaopin.yp=0;
        yaopin.shigaunflag = 0;
        pnqtlzpz.pnqt = 0;
        ypqtlzpz.ypqt = 0;
        pkqjqpguding.jqpflag = 0;
        pkqjyjg.flag = 0;
        pkqlzpz.js = 0;
        pkqlzpz.pzjs = 0;
        pkqlzpz.jg = 0;
        pkqsaomiao.gzflag = 0;
        dgtpd.dgtflag = 0;
        maojin.mjflag = 0;
        qmxsaizi.szflag = 0;
        pkqdgt.pkqdgtflag = 0;
        lzpz.jqb = 0;
        lzpz.ypqtgb = 0;
        yichu.ycqtgb = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
