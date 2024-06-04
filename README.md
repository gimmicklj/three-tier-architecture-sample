# Three Tier Architecture in ASP.NET Core 8 Web API

The three-tier architecture is a common software design pattern that divides an application into three logical layers: the User Interface Layer (UI), the Business Logic Layer (BLL), and the Data Access Layer (DAL). In ASP.NET Core 8 Web API, this architectural pattern helps maintain code clarity and maintainability, and also facilitates team collaboration and scalability.

## Project Structure

### User Interface Layer (UI)
The User Interface Layer is the topmost layer in the three-tier architecture, and its main responsibility is to present results to the user. In other words, this layer is responsible for obtaining data from the Business Logic Layer and displaying it to the front-end users. In Web API, the UI layer usually exists in the form of RESTful APIs, which interact with the front-end application through HTTP requests and responses.

**Responsibilities:**
- Receive user input and requests.
- Send requests to the Business Logic Layer.
- Display data returned by the Business Logic Layer.

### Business Logic Layer (BLL)
The Business Logic Layer is situated between the Data Access Layer and the User Interface Layer, and is responsible for handling activities that lead to logical decisions and evaluations. The main task of this layer is to process data between other layers.

**Responsibilities:**
- Receive requests from the UI layer.
- Call the Data Access Layer to retrieve or update data.
- Execute business rules and logic.
- Return the processed results to the UI layer.

### Data Access Layer (DAL)
The main function of the Data Access Layer is to access and store data in the database and pass the data to the Business Logic Layer, which ultimately passes it to the presentation layer according to user requests.

**Responsibilities:**
- Directly interact with the database, performing CRUD operations (Create, Read, Update, Delete).
- Convert data from the database into the format required by the Business Logic Layer.
- Handle data update requests from the Business Logic Layer and update the database.

---

![Responsive image](https://cdn.infodiagram.com/c/3fce42/3-tier-architecture-diagram.png)
