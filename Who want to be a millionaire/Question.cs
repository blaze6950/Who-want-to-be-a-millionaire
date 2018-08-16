using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Who_want_to_be_a_millionaire
{
    public class Question
    {
        private int _count = 0;
        private bool _isTrueAnswerDrop = false;
        private String _question;
        private String _trueAnswer;
        private List<String> _fakeAnswers;
        private List<String> _fakeAnswersOld = new List<string>();
        private Random rnd = new Random(DateTime.Now.Second);
        
        #region Constructors
        public Question(string question, string trueAnswer, List<String> fakeAnswers)
        {
            GeneralQuestion = question;
            TrueAnswer = trueAnswer;
            _fakeAnswers = fakeAnswers;
        }
        public Question(string question, string trueAnswer)
        {
            GeneralQuestion = question;
            TrueAnswer = trueAnswer;
            _fakeAnswers = new List<string>();
        }
        public Question(string question, string trueAnswer, string firstFakeAnswer,
            string secondFakeAnswer, string thirdFakeAnswer, string fourthFakeAnswer,
            string fifthFakeAnswer, string sixthFakeAnswer, string seventhFakeAnswer)
        {
            GeneralQuestion = question;
            TrueAnswer = trueAnswer;
            _fakeAnswers = new List<string>();
            _fakeAnswers.Add(firstFakeAnswer);
            _fakeAnswers.Add(secondFakeAnswer);
            _fakeAnswers.Add(thirdFakeAnswer);
            _fakeAnswers.Add(fourthFakeAnswer);
            _fakeAnswers.Add(fifthFakeAnswer);
            _fakeAnswers.Add(sixthFakeAnswer);
            _fakeAnswers.Add(seventhFakeAnswer);
        }
        #endregion

        #region Properties
        public String TakeAnswer
        {
            get
            {
                if (_count == 0)
                {
                    rnd = new Random(DateTime.Now.Millisecond - DateTime.Now.Second);
                }
                if (_count < 4)
                {
                    if (!_isTrueAnswerDrop)
                    {
                        if (rnd.Next(1, 3) == 2)
                        {
                            _isTrueAnswerDrop = !_isTrueAnswerDrop;
                            _count++;
                            return _trueAnswer;
                        }
                        else if (_count == 3)
                        {
                            _isTrueAnswerDrop = !_isTrueAnswerDrop;
                            _count++;
                            return _trueAnswer;
                        }
                        else
                        {
                            String str = _fakeAnswers[rnd.Next(0, _fakeAnswers.Count)];
                            _fakeAnswersOld.Add(_fakeAnswers[_fakeAnswers.IndexOf(str)]);
                            _fakeAnswers.Remove(str);
                            _count++;
                            return str;
                        }
                    }
                    else
                    {
                        String str = _fakeAnswers[rnd.Next(0, _fakeAnswers.Count)];
                        _fakeAnswersOld.Add(_fakeAnswers[_fakeAnswers.IndexOf(str)]);
                        _fakeAnswers.Remove(str);
                        _count++;
                        return str;
                    }
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public string GeneralQuestion
        {
            get { return _question; }
            set { _question = value; }
        }
        public string TrueAnswer
        {
            get { return _trueAnswer; }
            set { _trueAnswer = value; }
        }
        #endregion

        public bool IsItTrue(string str)
        {
            if (str == _trueAnswer)
            {
                return true;
            }
            return false;
        }

        public void ResetQuestion()
        {
            _count = 0;
            foreach (var fakeAnswersOld in _fakeAnswersOld)
            {
                _fakeAnswers.Add(fakeAnswersOld);
            }
            _fakeAnswersOld.Clear();
            _isTrueAnswerDrop = false;
        }
    }
}