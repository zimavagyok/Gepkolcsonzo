using System;
using System.Collections.Generic;
using System.Text;
using GepkolcsonzoModel;
using GepkolcsonzoModel.Entity;
using GepkolcsonzoRepository;

namespace GepkolcsonzoService
{
    public class GepService
    {
        private readonly GepRepository  _gepRepository= null;

        public GepService()
        {
            _gepRepository = new GepRepository();
        }

        public ResponseMessage<Gep> Create(Gep entity)
        {
            ResponseMessage<Gep> response = new ResponseMessage<Gep>();

            try
            {
                response.ResponseObject = _gepRepository.Create(entity);
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

        public ResponseMessage<Gep> Update(Gep entity)
        {
            ResponseMessage<Gep> response = new ResponseMessage<Gep>();

            try
            {
                response.ResponseObject = _gepRepository.Update(entity);
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

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                response.IsSuccess = _gepRepository.Delete(id);
                response.ErrorMessage = "Success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public int Elerheto(int id)
        {
            int response = 0;

            try
            {
                response = _gepRepository.Elerheto(id);
            }
            catch (Exception ex)
            {
            }

            return response;
        }
        public ResponseMessage<Gep> GetByID(int id)
        {
            ResponseMessage<Gep> response = new ResponseMessage<Gep>();

            try
            {
                response.ResponseObject = _gepRepository.GetByID(id);
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

        public ResponseMessage<List<Gep>> GetAll()
        {
            ResponseMessage<List<Gep>> response = new ResponseMessage<List<Gep>>();

            try
            {
                response.ResponseObject = _gepRepository.GetAll();
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

        public ResponseMessage<Gep> GetByName(string name)
        {
            ResponseMessage<Gep> response = new ResponseMessage<Gep>();

            try
            {
                response.ResponseObject = _gepRepository.GetByName(name);
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
