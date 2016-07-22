void setup() {
   // initialize serial communication at 9600 bits per second:
   Serial.begin(9600);
}
// the loop routine runs over and over again forever:
void loop() {
   // read the input on analog pin 0:
   int sensorValue = analogRead(A0);
   // print out the value you read:
   sensorValue= sensorValue -511;
   Serial.println(sensorValue);
   Serial.flush();
   delay(300);
   //delay(1);        // delay in between reads for stability
}
