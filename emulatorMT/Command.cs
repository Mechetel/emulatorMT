using System;
using System.Text.RegularExpressions;

namespace emulatorMT {
    class Command {
        public const String MOVE_LEFT = "L";
        public const String MOVE_RIGHT = "R";
        public const String MOVE_EMPTY = "E";

        public const String STATE_START = "00";// Номер начального состояния. Нужно менять в зависимости от команд (если отличается будет ошибка или бесконечный цикл)
        public const String STATE_END = "z";

        public String currentState;// Состояние
        public String[] currentSymbols;// Видимые символы на лентах
        public String newState;// Новое состояние
        public String[] newSymbols;// Новые символы на лентах
        public String[] moves;// Движения лент
        public String commandString;// Команда целиком (для вывода в лог)

        private Command(String currentState, String[] currentSymbols, String newState, String[] newSymbols, String[] moves, String commandString) {
            this.currentState = currentState;
            this.currentSymbols = currentSymbols;
            this.newState = newState;
            this.newSymbols = newSymbols;
            this.moves = moves;
            this.commandString = commandString;
        }

        /// <summary>
        /// Сверяет команду с содержимым ленты
        /// </summary>
        /// <param name="currentState"></param>
        /// <param name="currentSymbols"></param>
        /// <returns></returns>
        public bool isEquals(String currentState, String[] currentSymbols) {
            if (!this.currentState.Equals(currentState)) return false;

            if (this.currentSymbols.Length != currentSymbols.Length) return false;

            for(int i = 0; i < currentSymbols.Length; i++) {
                if (!this.currentSymbols[i].Equals(currentSymbols[i])) return false;
            }

            return true;
        }

        /// <summary>
        /// Возвращает количество лент на которое расчитана данная команда
        /// </summary>
        /// <returns>Количество лент</returns>
        public int getTapesCount() {
            return currentSymbols.Length;
        }

        /// <summary>
        /// Используется для создания команд из строки
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Command create(String str) {
            // Примеры команд
            // 2 ленты: q0_1,λ->q1_1,λ_R,E
            // 3 ленты: q0_1,λ,λ->q0_1,1,λ_R,R,E
            String regex = "q([\\d]+)_([\\S,]+)->q([\\d|z]+)_([\\S,]+)_([L,|R,|E,]+)";
            MatchCollection coll = Regex.Matches(str, regex);

            try {
                String currentState = coll[0].Groups[1].Value;

                String curS = coll[0].Groups[2].Value;
                String[] currentSymbols = curS.Split(',');

                String newState = coll[0].Groups[3].Value;

                String newS = coll[0].Groups[4].Value;
                String[] newSymbols = newS.Split(',');

                String mov = coll[0].Groups[5].Value;
                String[] moves = mov.Split(',');

                if (currentSymbols.Length != newSymbols.Length || newSymbols.Length != moves.Length) {
                    return null;
                }

                return new Command(currentState, currentSymbols, newState, newSymbols, moves, str);
            } catch (Exception ex) {
                Console.WriteLine("Неверный формат команды: \"" + str + "\"\n" + ex.StackTrace);
            }
            return null;
        }
    }
}
