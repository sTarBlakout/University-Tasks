
public class Lab7
{
    public class Bank
    {
        private double _stan;

        public double Wyplata(double value)
        {
            if (value > _stan)
            {
                Console.WriteLine("Prosisz za dużo!!!");
                return _stan;
            }

            _stan -= value;
            return _stan;
        }

        public double Wplata(double value)
        {
            _stan += value;
            return _stan;
        }

        public double Saldo()
        {
            return _stan;
        }
    }

    public class Zbior
    {
        private static int M_ROZ = 2000;
        protected int[] zbior = new int[M_ROZ];
        protected int roz = 0;

        public void Write()
        {
            for (int i = 0; i < roz; i++) Console.Write(zbior[i] + " ");
            Console.WriteLine();
        }

        public void dodaj(int n)
        {
            /*
            Dodaje liczbę n do zbioru liczb.
            Jeżeli podana liczba już istnieje dodawana jest po raz drugi
            n - liczba, którą należy dodać do zbioru
            */
            zbior[roz++] = n;
        }

        public void usun(int n)
        {
            /*
            Usuwa liczbę n ze zbioru liczb.
            W przypadku gdy zbiór nie posiada liczby podanej jako parametr
            rzucany jest wyjątek.
            n - liczba do usunięcia
            */
            var move = false;
            for (int i = 0; i < roz; i++)
            {
                if (zbior[i] == n)
                {
                    move = true;
                    continue;
                }

                if (move)
                {
                    zbior[i - 1] = zbior[i];
                }
            }

            if (move)
            {
                roz--;
            }
            else
            {
                throw new InvalidDataException("No such element in the list!");
            }
        }

        public int losuj()
        {
            /*
            Losuje jedną liczbę ze zbioru, usuwa ją ze zbioru, a następnie zwraca
            wylosowaną liczbę
            */
            var rnd = new Random();
            var idx = rnd.Next(roz);
            var rndNum = zbior[idx];
            usun(rndNum);
            return rndNum;
        }

        public int pobierzSume()
        {
            /*
            Zwraca sumę wszystkich liczb ze zbioru.
            zwraca sumę liczb.
            W przypadku pustego zbioru suma wynosi 0.
            */
            var sum = 0;
            for (int i = 0; i < roz; i++)
            {
                sum += zbior[i];
            }
            return sum;
        }

        public void iloraz_elem(int n)
        {
            /*
            Dzieli każdy element ze zbioru przez n bez reszty.
            n - liczba przez którą będzie wykonane dzielenie.
            */
            if (n == 0)
            {
                throw new InvalidDataException("Can't divide by zero!");
            }

            for (int i = 0; i < roz; i++)
            {
                zbior[i] = zbior[i] / n;
            }
        }

        public bool sprawdz(int n)
        {
            /*
            Sprawdza, czy w zbiorze istnieje element n
            n- element do sprawdzenia
            zwraca true w przypadku odnalezienia elementu, false w przeciwnym
            przypadku
            */

            for (int i = 0; i < roz; i++)
            {
                if (zbior[i] == n)
                {
                    return true;
                }
            }

            return false;
        }

        public int pobierz_rozmiar()
        {
            return roz;
        }
    }

    public interface StackExercise
    {
        /**
        * Usuwa i zwraca element znajdujący się
        * na szczycie stosu.
        * Generuje wyjątek StackEmptyException
        * gdy stos jest pusty.
*/
        public string pop(); //throws StackEmptyException;
        /**
        * Umieszcza element na szczycie stosu.
*/
        public void push(String item);
        /**
        * Zwraca element znajdujący się na szczycie
        * stosu, ale nie usuwa go stamtąd.
        * Generuje wyjątek StackEmptyException
        * gdy stos jest pusty.
*/
        public string top(); //throws StackEmptyException;
        /**
        * Zwraca true gdy stos jest pusty.
*/
        public bool isEmpty();
    }

    public class Stos : StackExercise
    {
        private Stack<string> stack = new Stack<string>();

        public bool isEmpty()
        {
            return stack.Count == 0;
        }

        public string pop()
        {
            if (isEmpty()) throw new InvalidOperationException("Is Empty!");
            return stack.Pop();
        }

        public void push(string item)
        {
            stack.Push(item);
        }

        public string top()
        {
            if (isEmpty()) throw new InvalidOperationException("Is Empty!");
            return stack.Peek();
        }
    }


    static void Main(string[] args)
    {
        
    }
}
