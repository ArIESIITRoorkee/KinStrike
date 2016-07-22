/* Basic Digital Read
 * ------------------ 
 *
 * turns on and off a light emitting diode(LED) connected to digital  
 * pin 13, when pressing a pushbutton attached to pin 7. It illustrates the
 * concept of Active-Low, which consists in connecting buttons using a
 * 1K to 10K pull-up resistor.
 *
 * Created 1 December 2005
 * copyleft 2005 DojoDave <http://www.0j0.org>
 * http://arduino.berlios.de
 *
 */

const int ledPin = 13; // choose the pin for the LED
const int inPin = 7;
const int mPin=9;// choose the input pin (for a pushbutton)
int val = 0;     // variable for reading the pin status

void setup() {
  Serial.begin(9600);
  
  pinMode(ledPin, OUTPUT);  // declare LED as output
  pinMode(inPin, INPUT); 
  pinMode(mPin, OUTPUT);// declare pushbutton as input

  digitalWrite(inPin,HIGH);
}


void loop(){
  if(digitalRead(inPin)==LOW)
  {
    Serial.println("/");
    Serial.flush();
    delay(50);
    digitalWrite(ledPin,LOW);
    digitalWrite(mPin,LOW);
  }

  else if(digitalRead(inPin)==HIGH)
  {
    Serial.println("*");
    Serial.flush();
    delay(50);
    digitalWrite(ledPin,HIGH);
    digitalWrite(mPin,HIGH);
  }


  int sensorValue = analogRead(A2);
   // print out the value you read:
   //sensorValue= sensorValue -511;
   Serial.println(sensorValue);
   Serial.flush();
   delay(50);
   //delay(1); 

  
}
