import LoginButton from "@/components/home/LoginButton";

const Navbar = () => {
  return (
    <div className="max-w-1196px mt-6 flex h-30px justify-between bg-background  px-4 md:px-32">
      <div className="flex h-30px cursor-pointer items-center text-xl font-bold leading-7 text-foreground">
        ONYX
      </div>
      <div className="z-30">
        <LoginButton />
      </div>
      
    </div>
  );
};
export default Navbar;