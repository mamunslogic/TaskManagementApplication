import "./App.css";
import CreateProject from "./features/project/CreateProject";
import ProjectList from "./features/project/ProjectList";
import UserList from "./features/user/UserList";
import UserRegistration from "./features/user/UserRegistration";

function App() {
  return (
    <div className="container mx-auto">
      <ProjectList />
    </div>
    // <div className="w-screen h-screen bg-blue-50 flex justify-center">
    //   <div className="max-w-md border-2 rounded-md my-20 bg-white opacity-90">
    //     <div className="bg-green-700 flex rounded shadow text-green-950 px-5 py-5">
    //       <h1 className="text-3xl font-bold underline">Task Management</h1>
    //     </div>
    //     <div>{/* <CreateTask /> */}</div>
    //   </div>
    // </div>
  );
}

export default App;
