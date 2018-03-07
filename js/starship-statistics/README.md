# Starship Descriptive Statistics

Welcome! You are a new intern for the Galactic Empire! Per regulation `7ff762b4-3a6d-400b-b4f6-792f59e60bbe`, the Empire has begun keeping detailed records and specifications of all known starship models.

Your task is to compile descriptive statistics regarding the cargo capacity of all starships. Your finished product should take the form of:

```
{
    "mean": 123,
    "median": 456,
    "mode": 200,
    "standardDeviation": 45
}
```

The Galactic Empire's source of truth is the [Star Wars API](https://swapi.co/). Please see the API [documentation](https://swapi.co/documentation#starships) on obtaining starship data.

As an intern of the Galactic Empire, you are expected to test drive all of the code you write. Please note that the internet connection aboard the death star is very flaky, due to ongoing repairs (there's like, this HUGE hole in the side of the ship). Your unit tests should be able to run and pass without a connection back to the Star Wars API. You should also have end-to-end tests proving that your solution will work in production, integrated with the API.
