1. Web Application Design Considerations:
		
    Partition your application logically
    Use abstraction to implement loose coupling between layers
    Understand how components will communicate with each other.
    Consider caching to minimize server round trips
    Consider logging and instrumentation
    Consider authenticating users across trust boundaries.
    Do not pass sensitive data in plaintext across the network
    Design your Web application to run using a least-privileged account
    Specific Design Issues:
		
			
    *    Application Request Processing
    *    Authentication
    *    Authorization
    *    Caching
    *    Exception Management
    *    Logging and Instrumentation
    *    Navigation
    *    Page Layout
    *    Page Rendering
    *    Session Management
    *    Validation	
	
1.  Client-side
	
    Choose an appropriate technology based on application requirements
    Separate presentation logic from interface implementation
    Apply separation of concerns across all layers
    Reuse common presentation logic
    Loosely couple your client from any remote services it uses.
    Avoid tight coupling to objects in other layers
    Reduce round trips when accessing remote layers.
    Specific Design Issues:
			
    *   Business Layer
    *   Server Communication (req/res object, interceptors, etc.)
    *   Configuration Management
    *   Exception Management
    *   State Management (App, Session, Cache, User, etc.)
    *   Workflow
    *   Authentication & Authorization
    *   Logging
    *   Navigation
    *   Message Management (including i18n)
    *   Focusable
    *   Validation		
		
	
	
1. Services
		
    Service exposed over the Internet
    Service exposed over an intranet
    Service exposed on the local machine
    Mixed scenario
    Consider using a layered approach to designing service applications and avoid tight coupling across layers
    Design coarse-grained operations
    Design data contracts for extensibility and reuse
    Design only for the service contract
    Design to assume the possibility of invalid requests
    Design services based on policy and with explicit boundaries
    Separate service concerns from infrastructure operational concerns
    Use separate assemblies for major components in the service layer (For example, the interface, implementation, data contracts, service contracts, fault contracts, and translators should all be separated into their own assemblies)
    Avoid using data services to expose individual tables in a database
    Specific Design Issues
				
    *   Authentication & Authorization
    *   Business Layer
    *   Communication
    *   Data Layer
    *   Exception Management
    *   Message Construction
    *   Message Endpoint
    *   Message Protection
    *   Message Transformation
    *   Message Exchange Patterns
    *   Service Layer
    *   SOAP, REST, gRPC
    *   Validation