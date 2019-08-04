package com.tm.MongoDbDemo;

import com.mongodb.client.*;
import org.bson.Document;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class MongoDbDemoApplication {

	public static void main(String[] args) {
		SpringApplication.run(MongoDbDemoApplication.class, args);

		MongoClient mongoClient = MongoClients.create("mongodb://localhost:27017");
		MongoDatabase database = mongoClient.getDatabase("test");
		MongoCollection<Document> collection = database.getCollection("col");
		FindIterable findIterable = collection.find();
		MongoCursor cursor = findIterable.iterator();
		while (cursor.hasNext()) {
			System.out.println(cursor.next());
		}
	}

}
