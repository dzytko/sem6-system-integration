import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URL;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        try {
            String temp_url = "http://localhost:8080/cities/read.php";
            URL url = new URL(temp_url);

            System.out.println("Wysyłanie zapytania...");
            InputStream is = url.openStream();

            System.out.println("Pobieranie odpowiedzi...");
            String source = new BufferedReader(new InputStreamReader(is)).lines().collect(Collectors.joining("\n"));
            source = "{\"cities\":" + source + "}";

            System.out.println("Przetwarzanie danych...");
            JSONObject json = new JSONObject(source);
            JSONArray receiveData = (JSONArray) json.get("cities");

            System.out.println("Cities: ");
            for (int i = 0; i < receiveData.length(); i++) {
                System.out.print("\tID: " + receiveData.getJSONObject(i).get("ID"));
                System.out.print(", Name: " + receiveData.getJSONObject(i).get("Name"));
                System.out.print(", Country code: " + receiveData.getJSONObject(i).get("CountryCode"));
                System.out.print(", Population: " + receiveData.getJSONObject(i).get("Population"));
                System.out.println(", District: " + receiveData.getJSONObject(i).get("District"));
            }


        } catch (Exception e) {
            System.err.println("Wystąpił nieoczekiwany błąd!!! ");
            e.printStackTrace(System.err);
        }
    }
}
