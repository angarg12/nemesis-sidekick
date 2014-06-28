using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

class MovementItemConverter : JsonConverter {
	public Movement Create(Type objectType, JObject jObject) {
		String type = (String)jObject.Property("type");

		string class_ = GlobalRegistry.get ("movement", type);
		return (Movement)Activator.CreateInstance(null, class_).Unwrap();

		throw new ApplicationException(String.Format("The movement type {0} is not supported!", type));
	}
	
	public override bool CanConvert(Type objectType){
		return typeof(Movement).IsAssignableFrom(objectType);
	}

	
	public override object ReadJson(JsonReader reader, 
	                                Type objectType, 
	                                object existingValue, 
	                                JsonSerializer serializer) {
		// Load JObject from stream 
		JObject jObject = JObject.Load(reader);
		
		// Create target object based on JObject 
		var target = Create(objectType, jObject);
		
		// Populate the object properties 
		serializer.Populate(jObject.CreateReader(), target);
		
		return target;
	}

	public override void WriteJson(JsonWriter writer, 
	                               object value,
	                               JsonSerializer serializer){
		throw new NotImplementedException();
	}
}