FROM openjdk
EXPOSE 5001
ADD transaction-app/target/spring-project-0.0.1-SNAPSHOT.jar transactions-app.jar
ENTRYPOINT ["java", "-jar", "/transactions-app.jar"]