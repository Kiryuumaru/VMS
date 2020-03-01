#include <Adafruit_Fingerprint.h>
#include <SoftwareSerial.h>
SoftwareSerial mySerial(2, 3);

Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

int id = 0;
int lastId = 0;
boolean finger1 = false;
boolean finger2 = false;

int getInt()
{
    int id = Serial.parseInt();
    while(Serial.available() > 0) char t = Serial.read();
    return id;
}

void getFingerprintEnroll() {
  if (!finger1){
    if (finger.getImage() != FINGERPRINT_OK) return;
    if (finger.image2Tz(1) != FINGERPRINT_OK) {
      Serial.println("ERR");
      id = 0;
      finger1 = false;
      finger2 = false;
      return;
    }
    Serial.println("OK1");
    finger1 = true;
    while (finger.getImage() != FINGERPRINT_NOFINGER);
  }
  
  if (!finger2){
    if (finger.getImage() != FINGERPRINT_OK) return;
    if (finger.image2Tz(2) != FINGERPRINT_OK) {
      Serial.println("ERR");
      id = 0;
      finger1 = false;
      finger2 = false;
      return;
    }
    if (finger.createModel() != FINGERPRINT_OK) {
      Serial.println("ERR");
      id = 0;
      finger1 = false;
      finger2 = false;
      return;
    }
    if (finger.storeModel(id) != FINGERPRINT_OK) {
      Serial.println("ERR");
      id = 0;
      finger1 = false;
      finger2 = false;
      return;
    }
    Serial.println("OK2");
    finger2 = true;
  }

  id = 0;
  finger1 = false;
  finger2 = false;
}

void getFingerprintID() {
  if (finger.getImage() != FINGERPRINT_OK)  return;
  if (finger.image2Tz() != FINGERPRINT_OK)  return;
  if (finger.fingerFastSearch() != FINGERPRINT_OK)  return;
  id = 0;
  Serial.println(finger.fingerID);
}

void setup()
{
  Serial.begin(9600);
  while (!Serial);
  delay(100);
  finger.begin(57600);
  
  if (finger.verifyPassword()) {
    Serial.println("OK");
  } else {
    Serial.println("ERR");
    while (1) { delay(1); }
  }
}

void loop() 
{
  if (Serial.available()) id = getInt();

  switch (id)
  {
    case 0: break;
    case -1:
      getFingerprintID();
      delay(50);
      break;
    case -2:
      finger.emptyDatabase();
      Serial.println("OK");
      id = 0;
      break;
    default:
      if (lastId != id){
        lastId = id;
        finger1 = false;
        finger2 = false;
      }
      getFingerprintEnroll();
      break;
  }
}
