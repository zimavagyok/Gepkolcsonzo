using System;
using System.Collections.Generic;
using GepkolcsonzoModel;
using GepkolcsonzoModel.Entity;
using GepkolcsonzoRepository;

namespace GepkolcsonzoService
{
    public class OsszekotesService
    {
        private readonly OsszekotesRepository _osszekotesRepository = null;

        public OsszekotesService()
        {
            _osszekotesRepository = new OsszekotesRepository();
        }

        public ResponseMessage<Osszekotes> Create(Osszekotes entity)
        {
            ResponseMessage<Osszekotes> response = new ResponseMessage<Osszekotes>();

            try
            {
                response.ResponseObject = _osszekotesRepository.Create(entity);
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResponseMessage<Osszekotes> GetByID(int id)
        {
            ResponseMessage<Osszekotes> response = new ResponseMessage<Osszekotes>();

            try
            {
                response.ResponseObject = _osszekotesRepository.GetByID(id);
                response.IsSuccess = true;
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
