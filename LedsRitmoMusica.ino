const int soundSensorPin = A1; // Pin analógico conectado al sensor de sonido
const int ledPins[] = {3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}; // Pines digitales conectados a los LEDs
const int numLeds = 12;
void setup() {
for (int i = 0; i < numLeds; i++) {
pinMode(ledPins[i], OUTPUT);
}
Serial.begin(9600);
}
void loop() {
int soundLevel = analogRead(soundSensorPin);
int numLedsToLight = map(soundLevel, 0, 1023, 0, numLeds);
String ledStates = "";
for (int i = 0; i < numLeds; i++) {
if (i < numLedsToLight) {
digitalWrite(ledPins[i], HIGH);
ledStates += "1";
} else {
digitalWrite(ledPins[i], LOW);
ledStates += "0";
}
}
Serial.println(ledStates);
delay(50); // Ajusta el delay para cambiar la capacidad de respuesta
}

