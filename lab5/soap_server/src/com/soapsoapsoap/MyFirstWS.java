package com.soapsoapsoap;

import javax.jws.WebService;
import java.time.Duration;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

@WebService(endpointInterface = "com.soapsoapsoap.MyFirstSOAPInterface")
public class MyFirstWS implements MyFirstSOAPInterface {
    public String getHelloWorldAsString(String nazwa) {
        return "Witaj " + nazwa + "!";
    }

    public long getDaysBetweenDates(String date1, String date2) {
        long numberOfDays = 0;
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd MM yyyy");
        try {
            LocalDate tempDate1 = LocalDate.parse(date1, dtf);
            LocalDate tempDate2 = LocalDate.parse(date2, dtf);
            numberOfDays = Duration.between(tempDate1.atStartOfDay(), tempDate2.atStartOfDay()).toDays();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return numberOfDays;
    }
}