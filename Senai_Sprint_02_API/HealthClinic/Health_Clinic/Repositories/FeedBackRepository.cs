using Health_Clinic.Contexts;
using Health_Clinic.Domains;
using Health_Clinic.Interfaces;

namespace Health_Clinic.Repositories
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly HealthClinicContext _healthContext;

        public FeedBackRepository()
        {
            _healthContext = new HealthClinicContext();
        }
        public void Cadastrar(FeedBack feedBack)
        {
            try
            {
                _healthContext.FeedBack.Add(feedBack);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                FeedBack feedbackBuscado = _healthContext.FeedBack.Find(id);

                if (feedbackBuscado != null)
                {
                    _healthContext.FeedBack.Remove(feedbackBuscado);
                }

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<FeedBack> Listar()
        {
            try
            {
                return _healthContext.FeedBack.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
