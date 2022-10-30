package Java;

import java.util.Map;

public class UberVan extends Car {
    Map<String, Map<String, Integer>> typeCarAccepted;
    Map<String, Map<String, Integer>> seatsMaterial;

    public UberVan(String license, Driver driver
    // , Map<String, Map<String, Integer>> typeCarAccepted,
    //         Map<String, Map<String, Integer>> seatsMaterial
            ) {
        super(license, driver);
        // this.typeCarAccepted = typeCarAccepted;
        // this.seatsMaterial = seatsMaterial;
    }

    @Override
    public void setPassenger(Integer passenger) {
        if (passenger == 6) {
            this.passenger = passenger;

        } else {
            System.out.println("Solo se aceptan 6 pasajeros.");
        }
    }
}
