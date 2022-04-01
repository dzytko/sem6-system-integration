package com.soapsoapsoap;
import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService
@SOAPBinding(style = Style.RPC)
public interface MyFirstSOAPInterface{
    @WebMethod String getHelloWorldAsString(String name);
    @WebMethod long getDaysBetweenDates(String date1,String date2);
}