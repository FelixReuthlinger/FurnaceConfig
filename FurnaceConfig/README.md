# Furnace Config

Mod to simply configure your blast furnace:
* Capacity ore
* Capacity fuel
* Fuel per ore consumption
* Seconds to create a bar

Yes, there are a lot of mods out there that do auto-fuel, but those also cause a lot of lags on servers.
This does just let you set your blast furnace values to your needs.

## Exposed config values

```
[FurnaceConfig]

## How much ore you can put at once into the furnace.
# Setting type: Int32
# Default value: 10
Maximum Ore Input Capacity = 10

## How much fuel (coal) you can put at once into the furnace.
# Setting type: Int32
# Default value: 20
Maximum Fuel Input Capacity = 20

## How many fuel items are consumed for one output product.
# Setting type: Int32
# Default value: 2
Fuel Per Product Consumption = 2

## How many seconds it will take to create one output product.
# Setting type: Int32
# Default value: 30
Seconds Per Product Duration = 30
```

## Changelog

* 0.1.0 -> initial release

## Contact

* https://github.com/FelixReuthlinger/FurnaceConfig
* Discord: Flux#0062 (you can find me around some of the Valheim modding discords, too)
