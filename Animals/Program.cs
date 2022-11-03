
using Animals;
using Animals.Records;

var myRecord = new ChildRecord("Vasya", 12);
var (_, age) = myRecord; // we need discard placeholder only for this
var (name, _) = myRecord;

var cat = new Cat("Murzik", 5);
cat.Voice();
cat.Walk();
var cotton = new ZPatreot("Nikolay", 32);
cotton.Voice();
cotton.Walk();