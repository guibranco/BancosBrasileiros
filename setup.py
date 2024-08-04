from setuptools import find_packages, setup

setup(
    name="bancos_brasileiros",
    version="0.1.0",
    author="Author Name",
    author_email="author@example.com",
    description="A description of the project",
    long_description=open("README.md").read(),
    long_description_content_type="text/markdown",
    url="https://github.com/username/repo",
    packages=find_packages(),
    classifiers=[
        "Programming Language :: Python :: 3",
        "License :: OSI Approved :: MIT License",
        "Operating System :: OS Independent",
    ],
    python_requires=">=3.6",
)
