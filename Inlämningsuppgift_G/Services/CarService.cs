using Inlämningsuppgift_G.Entities;
using Inlämningsuppgift_G.Models;
using Inlämningsuppgift_G.Repositories;

namespace Inlämningsuppgift_G.Services;

internal class CarService
{
    private readonly CarRepository _carRepository;
    private readonly CarModelRepository _carModelRepository;
    private readonly CarTypeRepository _carTypeRepository;

    public CarService(CarRepository carRepository, CarModelRepository carModelRepository, CarTypeRepository carTypeRepository)
    {
        _carRepository = carRepository;
        _carModelRepository = carModelRepository;
        _carTypeRepository = carTypeRepository;
    }

    public async Task<bool> CreateCarAsync(CarRegistrationForm form)
    {
       if (! await _carRepository.ExistsAsync(x => x.CarName == form.CarName))
        {
            var carModelEntity = await _carModelRepository.GetAsync(x => x.Model == form.CarModel);
            carModelEntity ??= await _carModelRepository.CreateAsync(new CarModelEntity { Model = form.CarModel });

            var carTypeEntity = await _carTypeRepository.GetAsync(x => x.Type == form.CarType);
            carTypeEntity ??= await _carTypeRepository.CreateAsync(new CarTypeEntity { Type = form.CarType });



            
            var carEntity = await _carRepository.CreateAsync(new CarEntity
            {
                CarName = form.CarName,
                CarPrice = form.CarPrice,
                CarModelId = carModelEntity.Id,
                CarTypeId = carTypeEntity.Id,
            });
            if (carEntity != null) 
                return true;
        }
       return false;
    }

    public async Task<IEnumerable<CarEntity>> GetAllAsync()
    {

        var cars = await _carRepository.GetAllAsync();
        return cars;
    }
}
