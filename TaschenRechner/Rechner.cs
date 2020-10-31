namespace specf1.TaschenRechner {
    static class Rechner {
        static public int Zahl1 { set; get; }
        static public int Zahl2 { set; get; }
        static public int Ergebnis { set; get; }

        static public void getAddieren() {
            Ergebnis =  Zahl1 + Zahl2;
        }
        static public void getSubtrahieren() {
            Ergebnis = Zahl1 - Zahl2;
        }
    }
}
