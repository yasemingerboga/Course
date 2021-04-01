using Business.Abstract;
using Core.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _carDal;
        public CardManager(ICardDal cardDal)
        {
            _carDal = cardDal;
        }
        public IResult Add(Card card)
        {
            _carDal.Add(card);
            return new SuccessResult();
        }

        public IResult Check(string cardNumber)
        {
            var result = _carDal.GetAll(c=>c.CardNumber== cardNumber);
            if (result.Count==1)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(Card card)
        {
            _carDal.Delete(card);
            return new SuccessResult();
        }

        public IResult Update(Card card)
        {
            _carDal.Update(card);
            return new SuccessResult();
        }
    }
}
