# Three Tier Architecture in ASP.NET Core 8 Web API

The three-tier architecture comprises the Presentation Layer(UI), Business Logic Layer (BLL), and Data Access Layer (DAL). In the context of an ASP.NET Core 8 Web API, this structure is instrumental in creating a scalable, maintainable, and efficient web application. The following sections delve into each layer, outlining their roles, responsibilities, and functions within the architecture.

## Project Structure

We use a three-tier architecture in this project, with an presentation layer, a business access layer, and a  data access layer. 

![Responsive image](https://cdn.infodiagram.com/c/3fce42/3-tier-architecture-diagram.png)

### Presentation Layer(UI)

**Responsibilities**:
- Receive user input.
- Display data to users.
- Handle logic related to the user interface.

**Functions**:
- Interact with the front-end application through Web API.
- Provide RESTful interfaces.
- Receive HTTP requests and return HTTP responses.

### Business Logic Layer (BLL)

**Responsibilities**:
- Handle business rules and decision-making logic.
- Connect the Presentation Layer with the Data Access Layer.

**Functions**:
- Receive requests from the Presentation Layer.
- Call the Data Access Layer to retrieve or update data.
- Execute business rules.
- Return the processed results to the Presentation Layer.

### Data Access Layer (DAL)

**Responsibilities**:
- Directly interact with the database.
- Perform CRUD operations (Create, Read, Update, Delete).
- Convert data into the format required by the Business Logic Layer.
- Handle data update requests from the Business Logic Layer and update the database.

**Functions**:
- Ensure the persistence of data.
- Ensure the efficiency of data access.

---

