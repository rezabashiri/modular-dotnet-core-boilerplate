<div id="top"></div>

<div align="center">
  <a href="https://github.com/rezabashiri/modular-dotnet-core-boilerplate">
   </a>

  <h3 align="center">Modular server/client template</h3>

  <p align="center">
    An easy to use template to show how to develop a fully stand-alone modulare application by .net 8
    <a href="https://github.com/rezabashiri/modular-dotnet-core-boilerplate/issues">Report Bug</a>
    ·
    <a href="https://github.com/rezabashiri/modular-dotnet-core-boilerplate/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->

## About The Project

In contemporary software development, the operational dynamics of microservices are widely acknowledged. The notion of discrete executables is indeed captivating, yet realizing this abstraction often entails significant costs, whether temporal or financial, particularly for small to mid-sized projects and organizations.

This template facilitates the consolidation of separate modules into a single executable, while ensuring that this amalgamation remains true to the essence of modularity. The modular design is not merely theoretical; rather, it encompasses entirely autonomous modules that can be effortlessly removed from the solution by eliminating a single line of code, without engendering any semantic or logical inconsistencies.

By adopting this template, you will:

- Attain a coherent and multi-modular code structure.
- Embrace an Onion architecture within each module.
- Enjoy support for multiple database types.
- Practice the SOLID principles in a programmatic context.
- Conduct both unit and integration tests.

This project aims to simplify complex development concepts and make them accessible to everyone. Feel free to use it in your own projects and see the benefits firsthand!

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

- [.net8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

- dotnet

### Installation

_Below is how you can run your project via docker compose._

1. Clone the repo
   ```sh
   git clone https://github.com/rezabashiri/modular-dotnet-core-boilerplate.git
   ```
2. Navigate to src/server
   ```sh
   dotnet build
   ```
3. ```sh
   dotnet run --project API/Bootstrapper.csproj
   ```
4. [Head to https://localhost:5001](https://localhost:5001)

**Or use visual studio code, visual studio or rider to up and run project**
<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ROADMAP -->

## Roadmap

- [ ] Add Docker support
- [ ] Add Blazer
- [ ] Add CQRS pattern

service to project

See the [open issues](https://github.com/rezabashiri/modular-dotnet-core-boilerplate/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTACT -->

## Contact

Reza Bashiri - [https://rezabashiri.com/](https://rezabashiri.com/) - rzbashiri@gmail.com - [Linkedin](https://www.linkedin.com/in/reza-bashiri/)

Project Link: [https://github.com/rezabashiri/modular-dotnet-core-boilerplate](https://github.com/rezabashiri/modular-dotnet-core-boilerplate)

<p align="right">(<a href="#top">back to top</a>)</p>
