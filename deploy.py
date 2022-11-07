# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.
import os
import xml.etree.ElementTree as ET

targetVersion = "0.5.0-alpha"
Output = "C:\\Users\\jackf\\Desktop\\pacs"
Source = "http://49.12.227.30:555/v3/index.json"
class ProjectNode:
    def __init__(self, filePath):
        self.file = filePath
        self.fileName = os.path.splitext(self.file.split("\\")[-1])[0]
        self.elementET = ET.parse(filePath)
        self.root = self.elementET.getroot()
        self.props = self.root.find("PropertyGroup")
        self.nodeDeps = self.root.findall("ItemGroup/PackageReference")
        self.Deps: list[ProjectNode] = []

    def __str__(self):
        return self.fileName + " |" + self.file

    def Activate(self, buffer):
        buffer: list[ProjectNode] = buffer
        version = self.props.find("Version")
        if version is None:
           version = ET.Element("Version")
           version.text = targetVersion
           self.props.append(version)
        else:
            version.text = targetVersion

        for dep in self.nodeDeps:
            attr = dep.attrib.get("Include")
            for proj in buffer:
                if attr == proj.fileName:
                    dep.attrib["Version"] = targetVersion
                    break

        self.elementET.write(self.file, encoding="utf-8")

        os.system("dotnet nuget locals temp --clear")
        os.system("dotnet nuget locals http-cache --clear")
        command = "dotnet pack " + self.file + " --output " + Output
        res = os.system(command)


        if res != 0:
            print("ERROR")
            return


        path = os.path.join(Output, self.fileName + "." + targetVersion + ".nupkg")

        command = "dotnet nuget push " + path + " --source " + Source
        res = os.system(command)
        if res != 0:
            print("ERROR 2")
            return

    def LinkedDeps(self, projects):
        for dep in self.nodeDeps:
            attr = dep.attrib.get("Include")
            for proj in projects:
                if attr == proj.fileName:
                    self.Deps.append(proj)
                    break





def alignTrees(input: list[ProjectNode]):
    buffer: list[ProjectNode] = []
    for proj in input:
        next = True
        for buf in buffer:
            if buf.fileName == proj.fileName:
                next = False
                break
        if next:
            alignTree(proj, buffer)

    return buffer

def alignTree(proj: ProjectNode, buffer: list[ProjectNode]):
    if len(proj.Deps) != 0:
        for dep in proj.Deps:
            next = True
            for buf in buffer:
                if buf.fileName == dep.fileName:
                    next = False
                    break

            if next:
                alignTree(dep, buffer)

    buffer.append(proj)


def print_hi(name):
    path = "C:\\Users\\jackf\\Documents\\ModuleGate"
    result = [os.path.join(dp, f) for dp, dn, filenames in os.walk(path) for f in filenames if
              os.path.splitext(f)[1] == '.csproj']

    projects = []
    for file in result:
        node = ProjectNode(file)
        projects.append(node)

    for proj in projects:
        proj.LinkedDeps(projects)

    ff = alignTrees(projects)
    for p in ff:
        print(p)
        p.Activate(ff)

        #eFile = ET.parse(file)
        #root = eFile.getroot()
        #props = root.find("PropertyGroup")
       #ersion = props.find("Version")
        #if version is None:
        #    version = ET.Element("Version")
        #    version.text = targetVersion
        #    props.append(version)
       # else:
       #     version.text = targetVersion
        #print(str(os.path.splitext(file)[0]))
        #eFile.write(file, encoding="utf-8")


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    print_hi('PyCharm')

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
