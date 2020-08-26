using diamond.AlphabetChain.Links;
using System.Collections.Generic;

namespace diamond.AlphabetChain
{
    public class AlphabetChain
    {
        private IHandler _handler;
        private Letter _letter;

        public AlphabetChain(Letter letter)
        {
            var a = new A();
            var b = new B();
            var c = new C();
            var d = new D();
            var e = new E();
            var f = new F();
            var g = new G();
            var h = new H();
            var i = new I();
            var j = new J();
            var k = new K();
            var l = new L();
            var m = new M();
            var n = new N();
            var o = new O();
            var p = new P();
            var q = new Q();
            var r = new R();
            var s = new S();
            var t = new T();
            var u = new U();
            var v = new V();
            var w = new W();
            var x = new X();
            var y = new Y();
            var z = new Z();

            y.SetNext(z);
            x.SetNext(y);
            w.SetNext(x);
            v.SetNext(w);
            u.SetNext(v);
            t.SetNext(u);
            s.SetNext(t);
            r.SetNext(s);
            q.SetNext(r);
            p.SetNext(q);
            o.SetNext(p);
            n.SetNext(o);
            m.SetNext(n);
            l.SetNext(m);
            k.SetNext(l);
            j.SetNext(k);
            i.SetNext(j);
            h.SetNext(i);
            g.SetNext(h);
            f.SetNext(g);
            e.SetNext(f);
            d.SetNext(e);
            c.SetNext(d);
            b.SetNext(c);
            a.SetNext(b);
            _handler = a;
            _letter = letter;
        }
        public List<PaddedDiamondRow> Execute()
        {
            return _handler.Handle(_letter, new DiamondDepth(0));
        }
    }
}
