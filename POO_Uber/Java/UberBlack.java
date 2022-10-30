package Java;

import java.util.Map;

public class UberBlack extends Car {
    Map<String, Map<String, Integer>> typeCarAccepted;
    Map<String, Map<String, Integer>> seatsMaterial;

    public UberBlack(String license, Driver driver, Map<String, Map<String, Integer>> typeCarAccepted,
            Map<String, Map<String, Integer>> seatsMaterial) {
        super(license, driver);
        this.typeCarAccepted = typeCarAccepted;
        this.seatsMaterial = seatsMaterial;
    }
}
