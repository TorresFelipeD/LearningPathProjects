from car import Car
from driver import Driver

if __name__ == "__main__":
    print("Hola Mundo")

    car = Car("ABC852", Driver("Julian Perez","84512663","eds@kdo.co","sdc5ds1"))
    car.passenger = 2
    print(vars(car))
    print(vars(car.driver))
