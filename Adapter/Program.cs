using System;


/*
 * Гітара генерує аналоговий сигнал. Комбопідсилювач його без проблем 
 * приймає та може гучніше відтворювати гітарну гру. Проте якщо хочемо обробити гітарний звук 
 * через комп'ютер та вивести його на комбопідсилювач з різними ефектами - 
 * потрібен адаптер, адже комп'ютер може приймати та генерувати лише цифровий сигнал. 
 * Використовуючи патерн адаптер дати змогу метал фанату грати не лише блюз 
 */



namespace AudioAdapterExample
{
    class ElectricGuitar
    {
        public string OutputAnalogSignal()
        {
            return "guitar makes analog signal";
        }
    }

    interface IDigitalEffectsProcessor
    {
        string ProcessDigitalSignal(string digitalSignal);
    }

    class ComputerWithEffects : IDigitalEffectsProcessor
    {
        public string ProcessDigitalSignal(string digitalSignal)
        {
            return "digital signals with mix of guitar sounds and effects";
        }
    }

    class AudioAdapter : IDigitalEffectsProcessor
    {
        private ElectricGuitar guitar;
        private ComputerWithEffects computer;

        public AudioAdapter(ElectricGuitar guitar, ComputerWithEffects computer)
        {
            this.guitar = guitar;
            this.computer = computer;
        }

        public string ProcessDigitalSignal(string digitalSignal)
        {
            string analogSignal = guitar.OutputAnalogSignal();
            string convertedSignal = "analog signal converted to digital";

            string processedSignal = computer.ProcessDigitalSignal(convertedSignal);

            return "processed sounds converted back to analog signal";
        }
    }

    class Amplifier
    {
        public void PlaySound(string analogSignal)
        {
            Console.WriteLine(" * Loud guitar sounds * ");
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            //можемо грати просто через комбопідсилювач 
            var guitar = new ElectricGuitar();
            var amplifier = new Amplifier();
            var guitarsSound = guitar.OutputAnalogSignal();
            amplifier.PlaySound(guitarsSound);

            //або ж з якимось комп'ютерними ефектами 
            var computer = new ComputerWithEffects();

            //проте не зможемо зробити це без адаптера...
            var adapter = new AudioAdapter(guitar, computer);

            //..який би перетворював аналоговий тип сигналу на цифровий та назад
            string finalSound = adapter.ProcessDigitalSignal(guitar.OutputAnalogSignal());

            //тепер можемо грати з більш різноманітним звуком !
            amplifier.PlaySound(finalSound);

            Console.ReadKey();
        }
    }
}